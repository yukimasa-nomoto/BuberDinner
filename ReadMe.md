2022/12/12
Part5 FlowControl
	エラーの取り方を変更していく　4か所
		Application
			CommonにErrorsを作る
		DatetimeProviderもエラー出すらしい
		↓
		「oneOf」を使うやり方
		↓
		「FluentResults」を使うやり方
			IErrorとかある
		↓
		「ErrorOr & DomainErrors」
			DomainにErrorOrをインストール
				Domainにエラーをまとめてる。Applicationに分けるのも良いね！とは言ってそう
			Errors.User.csを作成
			Appicationでも「ErrorOr」が使えるね。
			↓
			Exception出なくても判定できるように対応
			↓
			Loginも修正
				Errorsをpartialに
			↓
			ApiControllerにエラーを集結
		↓
		customValueも設定
			ApiControllerのProblemでHttpContextに放り込む
			factoryで引き出す
一旦Up

Part6（CQRS+MedeiatR）
	IAuthencicationServiceをCommandに
	Queryも用意する
	↓
	丁寧に分けても冗長なので
	Commandにする(Serviceをやめる)
	↓
	それならMediatRを使おう！
		ApplicationにMediatRをインストール
		で、Apiで使う
			sendでよんで、
			CommandとHandlerをApplication内に作る
	↓
	MediatRのExtensionもいれる。DIで呼ぶときに使用
	↓
	動作完了
		hub的なものを作らないでもよくなった。

一旦Up

Part7(Object Mapping)

	

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
	・1つ目
		Middleware作成
			UseMiddlewareを使う
	・2つ目
		Filters作成
			AddControllersに追加
	・3つ目
		RFCの基準にのっとる
			problemDetailsの形に
			AddControllersからはずす
				UseExceptionHandlerに変更
				ErrorsControllerも用意
					Problemを返したら、いい感じになった
						typeとか。traceIdとか
		↓
		Factoryとかを用意すればDefaultのメッセージを変更可能

		builderについか?
		良く分からんまま終わった

いったんアップ


		

2022/12/08
ApiとContractsが一緒（PresentationLayer）
	ContractsはAppicationを参照しない

EndPointとは、apiを呼ぶこと？
IDとトークンを返すように作成

apiで、そのまま返すのは確認済み

