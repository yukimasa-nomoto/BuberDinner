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

Part5 FlowControl

		

2022/12/08
Api��Contracts���ꏏ�iPresentationLayer�j
	Contracts��Appication���Q�Ƃ��Ȃ�

EndPoint�Ƃ́Aapi���ĂԂ��ƁH
ID�ƃg�[�N����Ԃ��悤�ɍ쐬

api�ŁA���̂܂ܕԂ��̂͊m�F�ς�

