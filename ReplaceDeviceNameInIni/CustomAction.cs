using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Deployment.WindowsInstaller;
using System.IO;

namespace ReplaceDeviceNameInIni
{
    public class CustomActions
    {
        [CustomAction]
        public static ActionResult ReplaceDeviceNameInIni(Session session)
        {
            try
            {
                // CustomActionData를 통해 전달된 값 가져오기
                string installFolder = session.CustomActionData["INSTALLFOLDER"];
                string deviceName = session.CustomActionData["DEVICE_NAME"];
                // 장치명이 없으면 기본값 입력
                if (string.IsNullOrEmpty(deviceName))
                {
                    deviceName = "장치이름입력";
                }
                // 탬플릿 파일 경로와 파일 쓰기 경로
                string templatePath = Path.Combine(installFolder, "frpc_template.ini");
                string finalPath = Path.Combine(installFolder, "frpc.ini");
                // 탬플릿 파일을 읽어와 입력받은 장치명을 파일에 치환
                string content = File.ReadAllText(templatePath);
                content = content.Replace("[devicename]", $"[{deviceName}]");
                // UTF-8 인코딩으로 파일 작성
                // File.WriteAllText(finalPath, content, Encoding.UTF8); // UTF-8 with BOM
                File.WriteAllText(finalPath, content, new UTF8Encoding(false)); // UTF-8
                // 결과 반환
                return ActionResult.Success;
            }
            catch (Exception ex)
            {
                // 오류 발생 시 예외처리
                session.Log("ERROR in ReplaceDeviceNameInIni: " + ex.ToString());
                return ActionResult.Failure;
            }
        }
    }
}
