
  # frpcgui_installer 
  frpc 를 간편하게 사용할 수 있게 도와주는 MFC 프로젝트 'FRP GUI Client'의 자동배포를 위한 설치패키지입니다.  
  이 프로젝트는 'fatedier/frp' 의 frpc 특정 버전을 리소스로 내장하고 있습니다.  
  This is an installation package for automatic distribution of the MFC project 'FRP GUI Client' that helps you use frpc easily.  
  This project embeds a specific version of frpc from 'fatedier/frp' as a resource.
  
  ### 요구사항
  1. Windows 7 서비스팩 1 이상
  ### Requirements
  1. Windows 7 Service Pack 1 or later  

  ### Automatic distribution command (Run as administrator)
  msiexec /i frpcgui_installer.msi DEVICE_NAME="device_name_here" /quiet /norestart
