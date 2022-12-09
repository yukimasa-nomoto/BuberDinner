2022/12/09
次は、ApplicationLayerでAuthを行う
（31:35）
	dependencyindection.abstractionをインストール
		別途DependencyをApplicationで行うように修正

JWTトークン作成
	Applicationにインターフェイス。その処理を実装
	なかみはInfrastructure側に構築
		system.identityModel.Tokens.Jwtをインストール
	「jwt.io」で中身を確認可能
	↓
	ハードコーディングを辞める
		appsettings.jsonに記載
		appsettings.development.jsonに記載
		↓
		読むのはInfrastructure??
			builder.configuration使う
			extension.configurationをインストール
			extension.options.configurationをインストール
			コンストラクタ時にIOptionをつける

Part3
	DomainにUser作成
	RepostitoryPatternについて
		コマンドとかはまだ

一旦Up

Part4 Global Error Handling

2022/12/08
ApiとContractsが一緒（PresentationLayer）
	ContractsはAppicationを参照しない

EndPointとは、apiを呼ぶこと？
IDとトークンを返すように作成

apiで、そのまま返すのは確認済み

