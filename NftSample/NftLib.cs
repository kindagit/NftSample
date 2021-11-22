using ERC721ContractLibrary.Contracts.ERC721PresetMinterPauserAutoId;
using ERC721ContractLibrary.Contracts.ERC721PresetMinterPauserAutoId.ContractDefinition;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.XUnitEthereumClients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NftSample
{
    public class NftLib
    {
        EthereumClientIntegrationFixture client_;
        Web3 web3_;
        ERC721PresetMinterPauserAutoIdService service_;

        public NftLib(string contractAddress = null, InfuraNetwork network = InfuraNetwork.Ropsten)
        {
            client_ = new EthereumClientIntegrationFixture();
            if (network == InfuraNetwork.Mainnet)
                web3_ = client_.GetWeb3();          // appsettings.json을 이용함
            else
                web3_ = client_.GetInfuraWeb3(network);

            // contractAddress가 있다면 service 할당
            if (false == string.IsNullOrEmpty(contractAddress))
                service_ = new ERC721PresetMinterPauserAutoIdService(web3_, contractAddress);
        }

        /// <summary>
        /// 토큰을 생성한다. 토큰을 생성한 이후에는 사용하면 안된다.
        /// 여기서 contractAddress를 구한다.
        /// </summary>
        /// <param name="baseUri"></param>
        /// <param name="name"></param>
        /// <param name="symbol"></param>
        /// <param name="bytecode">Solidity를 컴파일한 bytes</param>
        /// <returns>트랜잭션의 영수증</returns>
        public async Task<TransactionReceipt> CreateNFTToken(string baseUri, string name, string symbol, string bytecode)
        {
            try
            {
                var erc721PresetMinter = new ERC721PresetMinterPauserAutoIdDeployment(bytecode)
                {
                    //BaseURI = baseUri,
                    Name = name,
                    Symbol = symbol
                };

                var receipt = await ERC721PresetMinterPauserAutoIdService.DeployContractAndWaitForReceiptAsync(web3_, erc721PresetMinter);
                service_ = new ERC721PresetMinterPauserAutoIdService(web3_, receipt.ContractAddress);   // service 할당
                return receipt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        /// <summary>
        /// 새로운 TokenID를 생성하고 소유권을 준다.
        /// </summary>
        /// <param name="to">소유권을 가진 address</param>
        /// <returns>트랜잭션의 영수증</returns>
        public async Task<TransactionReceipt> Mint(string to, string uri)
        {
            try
            {
                if (string.IsNullOrEmpty(to))
                    to = client_.AccountAddress;
                return await service_.MintRequestAndWaitForReceiptAsync(to);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        public async Task<TransactionReceipt> SafeMint(string to, string uri)
        {
            try
            {
                if (string.IsNullOrEmpty(to))
                    to = client_.AccountAddress;
                return await service_.SafeMintRequestAndWaitForReceiptAsync(to, uri);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        public async Task<TransactionReceipt> SafeMintGuppy(string to, string guppyInfo)
        {
            try
            {
                if (string.IsNullOrEmpty(to))
                    to = client_.AccountAddress;
                return await service_.SafeMintGuppyRequestAndWaitForReceiptAsync(to, guppyInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        /// <summary>
        /// Token Id가 가리키는 GuppyInfo
        /// </summary>
        public async Task<string> GuppyInfo(BigInteger tokenId)
        {
            try
            {
                return await service_.GuppyInfoQueryAsync(tokenId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return "";
        }

        /// <summary>
        /// 토큰의 소유자 자산을 확인
        /// </summary>
        public async Task<BigInteger> BalanceOf(string address)
        {
            try
            {
                return await service_.BalanceOfQueryAsync(address);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return 0;
        }

        /// <summary>
        /// 토큰의 소유자 Address를 확인
        /// </summary>
        public async Task<string> OwnerOfToken(BigInteger tokenId)
        {
            try
            {
                return await service_.OwnerOfQueryAsync(tokenId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return "";
        }

        /// <summary>
        /// 생성된 Token Id의 갯수
        /// </summary>
        public async Task<BigInteger> TotalTokenCount()
        {
            try
            {
                return await service_.TotalSupplyQueryAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return 0;
        }

        /// <summary>
        /// Token Id가 가리키는 URI
        /// </summary>
        public async Task<string> TokenURI(BigInteger tokenId)
        {
            try
            {
                return await service_.TokenURIQueryAsync(tokenId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return "";
        }

        /// <summary>
        /// 토큰 전송 권한을 부여
        /// </summary>
        public async Task<string> Approve(string toAddress, BigInteger tokenId)
        {
            try
            {
                return await service_.ApproveRequestAsync(toAddress, tokenId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return "";
        }

        /// <summary>
        /// 
        /// </summary>
        public async Task<string> GetApproved(BigInteger tokenId)
        {
            try
            {
                return await service_.GetApprovedQueryAsync(tokenId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return "";
        }
    }
}
