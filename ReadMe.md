2022/12/20
Part12
	Domain Common ModelsにValueObjectをabstractで作成
	↓
	Entityも作成
	↓
	AggregateRootも作成
一旦Up


Part13
どういうフォルダー構成にするか？
	Menuというフォルダーから開始する事とする
		メニュークラスを作成(AggregateRoot)
		↓
		MenuIdというValueOjectが必須
			Guidにして、CreateUniqueメソッドも作る
			コンストラクタはprivateにして




2022/12/13
Part7(Object Mapping)
	APIに「Mapster」「Mapster.DependencyInjection」をインストール
	↓
	common mapping フォルダーに共通処理[AuthenticationMappingConfigure]作成
	これをcallするDependencyInjectionを作成
	↓
	DependencyInjectionをAddPresentationで用意する
		mapping用に用意したDependencyInjectionをCall

一旦Up

Part8(Fluent Validation)
	application common behaviors
	まずMediatRのIPipelineBehaviorを記載
		commandの実行前、後を取得可能
		Dependecyに追加
		RegisterCommandで確認OK
	↓
	ApplicationにFluentValidationをインストール
		RegisterCommandValidatorを作成
			AbstractValidatorを継承
		Dependencyに追加
			(IValidatorで)
			
		↓
		FluentValidation.AspNetCoreをインストール
			１こ１こ登録がめんどくさいから
	↓
	TRequestとTResponseで再構築
		ValidationBehaviorに変更
		dynamicで逃げる
		dependencyInjectionにすべて登録
		コンストラクタ引数にnull追加
	↓
	ApiControllerの修正
		ModelStateDictionaryを用意
	↓
	LoginQueryValidatorの追加

一旦Up

Part9(DinnersController Authenticate user 用)
	UseAuthentication使用
	AddInfrastructureをAddAuthとわける
	InfrastructureにJwtBearerをインストール
		tokenを持っている人を認証とする？
	↓
	何やら記載
	↓
	DinnersControllerで
	this.HttpContext.User.Identity.IsAuthenticated=falseを確認
	↓
	Getにトークンをつけて、再確認
		IsAuthenticatedまで確認OK
	↓
	UseAuthorizationもつける
		これで、アクセス可、不可をやってるっぽい
	↓
	ApiControllerに[Authorize]をつけて
	AuthenticationControllerに[AllowAnonymous]を付けて対応

一旦Up

Part10
Part11(Aggregates {Entity,ValueObject(IDで渡す奴)})

一旦Up



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

