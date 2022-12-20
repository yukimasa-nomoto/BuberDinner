2022/12/20
Part12
	Domain Common Models��ValueObject��abstract�ō쐬
	��
	Entity���쐬
	��
	AggregateRoot���쐬
��UUp


Part13
�ǂ������t�H���_�[�\���ɂ��邩�H
	Menu�Ƃ����t�H���_�[����J�n���鎖�Ƃ���
		���j���[�N���X���쐬(AggregateRoot)
		��
		MenuId�Ƃ���ValueOject���K�{
			Guid�ɂ��āACreateUnique���\�b�h�����
			�R���X�g���N�^��private�ɂ���




2022/12/13
Part7(Object Mapping)
	API�ɁuMapster�v�uMapster.DependencyInjection�v���C���X�g�[��
	��
	common mapping �t�H���_�[�ɋ��ʏ���[AuthenticationMappingConfigure]�쐬
	�����call����DependencyInjection���쐬
	��
	DependencyInjection��AddPresentation�ŗp�ӂ���
		mapping�p�ɗp�ӂ���DependencyInjection��Call

��UUp

Part8(Fluent Validation)
	application common behaviors
	�܂�MediatR��IPipelineBehavior���L��
		command�̎��s�O�A����擾�\
		Dependecy�ɒǉ�
		RegisterCommand�Ŋm�FOK
	��
	Application��FluentValidation���C���X�g�[��
		RegisterCommandValidator���쐬
			AbstractValidator���p��
		Dependency�ɒǉ�
			(IValidator��)
			
		��
		FluentValidation.AspNetCore���C���X�g�[��
			�P���P���o�^���߂�ǂ���������
	��
	TRequest��TResponse�ōč\�z
		ValidationBehavior�ɕύX
		dynamic�œ�����
		dependencyInjection�ɂ��ׂēo�^
		�R���X�g���N�^������null�ǉ�
	��
	ApiController�̏C��
		ModelStateDictionary��p��
	��
	LoginQueryValidator�̒ǉ�

��UUp

Part9(DinnersController Authenticate user �p)
	UseAuthentication�g�p
	AddInfrastructure��AddAuth�Ƃ킯��
	Infrastructure��JwtBearer���C���X�g�[��
		token�������Ă���l��F�؂Ƃ���H
	��
	�����L��
	��
	DinnersController��
	this.HttpContext.User.Identity.IsAuthenticated=false���m�F
	��
	Get�Ƀg�[�N�������āA�Ċm�F
		IsAuthenticated�܂Ŋm�FOK
	��
	UseAuthorization������
		����ŁA�A�N�Z�X�A�s������Ă���ۂ�
	��
	ApiController��[Authorize]������
	AuthenticationController��[AllowAnonymous]��t���đΉ�

��UUp

Part10
Part11(Aggregates {Entity,ValueObject(ID�œn���z)})

��UUp



2022/12/12
Part5 FlowControl
	�G���[�̎�����ύX���Ă����@4����
		Application
			Common��Errors�����
		DatetimeProvider���G���[�o���炵��
		��
		�uoneOf�v���g������
		��
		�uFluentResults�v���g������
			IError�Ƃ�����
		��
		�uErrorOr & DomainErrors�v
			Domain��ErrorOr���C���X�g�[��
				Domain�ɃG���[���܂Ƃ߂Ă�BApplication�ɕ�����̂��ǂ��ˁI�Ƃ͌����Ă���
			Errors.User.cs���쐬
			Appication�ł��uErrorOr�v���g����ˁB
			��
			Exception�o�Ȃ��Ă�����ł���悤�ɑΉ�
			��
			Login���C��
				Errors��partial��
			��
			ApiController�ɃG���[���W��
		��
		customValue���ݒ�
			ApiController��Problem��HttpContext�ɕ��荞��
			factory�ň����o��
��UUp

Part6�iCQRS+MedeiatR�j
	IAuthencicationService��Command��
	Query���p�ӂ���
	��
	���J�ɕ����Ă��璷�Ȃ̂�
	Command�ɂ���(Service����߂�)
	��
	����Ȃ�MediatR���g�����I
		Application��MediatR���C���X�g�[��
		�ŁAApi�Ŏg��
			send�ł��ŁA
			Command��Handler��Application���ɍ��
	��
	MediatR��Extension�������BDI�ŌĂԂƂ��Ɏg�p
	��
	���슮��
		hub�I�Ȃ��̂����Ȃ��ł��悭�Ȃ����B

��UUp



	

2022/12/09
���́AApplicationLayer��Auth���s��
�i31:35�j
	dependencyindection.abstraction���C���X�g�[��
		�ʓrDependency��Application�ōs���悤�ɏC��

JWT�g�[�N���쐬
	Application�ɃC���^�[�t�F�C�X�B���̏���������
	�Ȃ��݂�Infrastructure���ɍ\�z
		system.identityModel.Tokens.Jwt���C���X�g�[��
	�ujwt.io�v�Œ��g���m�F�\
	��
	�n�[�h�R�[�f�B���O�����߂�
		appsettings.json�ɋL��
		appsettings.development.json�ɋL��
		��
		�ǂނ̂�Infrastructure??
			builder.configuration�g��
			extension.configuration���C���X�g�[��
			extension.options.configuration���C���X�g�[��
			�R���X�g���N�^����IOption������

Part3
	Domain��User�쐬
	RepostitoryPattern�ɂ���
		�R�}���h�Ƃ��͂܂�

��UUp

Part4 Global Error Handling
	�E1��
		Middleware�쐬
			UseMiddleware���g��
	�E2��
		Filters�쐬
			AddControllers�ɒǉ�
	�E3��
		RFC�̊�ɂ̂��Ƃ�
			problemDetails�̌`��
			AddControllers����͂���
				UseExceptionHandler�ɕύX
				ErrorsController���p��
					Problem��Ԃ�����A���������ɂȂ���
						type�Ƃ��BtraceId�Ƃ�
		��
		Factory�Ƃ���p�ӂ����Default�̃��b�Z�[�W��ύX�\

		builder�ɂ���?
		�ǂ��������܂܏I�����

��������A�b�v


		

2022/12/08
Api��Contracts���ꏏ�iPresentationLayer�j
	Contracts��Appication���Q�Ƃ��Ȃ�

EndPoint�Ƃ́Aapi���ĂԂ��ƁH
ID�ƃg�[�N����Ԃ��悤�ɍ쐬

api�ŁA���̂܂ܕԂ��̂͊m�F�ς�

