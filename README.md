# NFT 샘플
## 목차
[0.사전 준비](#사전-준비)<br>
[1.계정 생성](#계정-생성)<br>
[2.계정에 이더 보내기](#계정에-이더-보내기)<br>
[3.C#샘플](#샘플)<br>
[4.Console명령어](#Console명령어)<br>
<br>
<br>
## 사전 준비
- Ethereum은 정식 서비스인 Mainnet과 Testnet(Ropsten, Kovan, Rinkeby)들이 있다.
- Ethereum을 이용하기 위한 Client프로그램에는 geth, openethereum, ganache등을 설치해서 사용해야 하지만 [Infura]를 이용하면 exe가 없어도 작업이 가능하다.
[Infura]사용 방법은 [Google:Infura]에서 검색한다.
- [Solidity](https://docs.soliditylang.org/en/v0.8.10/)는 Ethereum의 [Smart contract](https://ethereum.org/en/developers/docs/smart-contracts/)를 작성하는 언어이다.
- NFT(Non-Fungible Token)는 Smart contract의 ERC721 Token를 의미한다.
<br>
<br>
## 지갑의 Address 생성
- 크롬에 Metamask를 설치하고 계정을 생성하여 이더리움의 Address를 확인한다. 자세한 방법은 [Google:Metamask]에서 검색한다.<br>
생성된 Address는 우주의 분자보다 많은 수중 하나의 확율이기 때문에 중복될 일은 거의 없다고 보면 된다.<br>
생성된 Address는 특정한 네트워크에 귀속되는게 아니기 때문에 어디서든 사용 가능하다.<br>
테스트를 위한 네트워크는 Ropsten으로 설정한다.
- [Infura]에서 계정을 생성 후 PROJECT ID를 C#샘플의 appsettings.json에 적용한다.
<br>
<br>
## Address에 이더 보내기
- [Ropsten faucet]으로 가서 Address를 입력하고 이더리움을 보낸다.
<br>
<br>
## 샘플
- 이프로젝트는 [NEthereum](https://github.com/Nethereum/ERC721ContractLibrary.Template)을 이용하여 제작 함<br>
- 테스트 네트워크는 Ropsten이다.

1. 프로젝트를 열고 appsettings.json의 AccountAddress, AccountPrivateKey, InfuraNetwork, InfuraId에 [계정 생성](#계정-생성)에서 만든 값들로 셋팅 한다.
<br>
<br>
## Console명령어
1. create : Contract 생성<br>
- ex] create
2. total : 생선도니 Token 갯수 확인
- ex] total
3. mint : 토큰 추가
- ex] mint:toAddress,guppyInfo
- ex] mint:0xD08BC093f4Acc6Ebe21842351DBF74273c445A00,sampleinfo
4. ownerof : 소유자 확인
- ex] ownerof:tokenid
- ex] ownerof:0
5. approve : 해당 토큰에 거래 권한 주기
- ex] approve:toAddress
- ex] approve:0xD08BC093f4Acc6Ebe21842351DBF74273c445A00
6. getapproved : 해당 토큰의 거래 권한자 확인
- ex] approve:tokenId
- ex] approve:0
7. guppyinfo : 커스텀데이타의 내용 확인
- ex] guppyinfo:tokenId
- ex] guppyinfoapprove:0

[Google:Infura]:https://www.google.com/search?q=Infura+%EC%82%AC%EC%9A%A9%EB%B2%95&rlz=1C1GCEU_koKR933KR933&oq=Infura+%EC%82%AC%EC%9A%A9%EB%B2%95&aqs=chrome..69i57j69i60.7081j0j7&sourceid=chrome&ie=UTF-8
[Google:Metamask]:https://www.google.com/search?q=Metamask+%EC%84%A4%EC%B9%98+%EB%B0%8F+%EA%B3%84%EC%A0%95+%EC%83%9D%EC%84%B1&rlz=1C1GCEU_koKR933KR933&oq=Metamask+%EC%84%A4%EC%B9%98+%EB%B0%8F+%EA%B3%84%EC%A0%95+%EC%83%9D%EC%84%B1&aqs=chrome..69i57j33i160l4.9129j0j15&sourceid=chrome&ie=UTF-8
[Infura]:(https://infura.io/)
[Ropsten faucet]:https://faucet.ropsten.be/