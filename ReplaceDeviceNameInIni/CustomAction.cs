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
                // CustomActionData�� ���� ���޵� �� ��������
                string installFolder = session.CustomActionData["INSTALLFOLDER"];
                string deviceName = session.CustomActionData["DEVICE_NAME"];
                // ��ġ���� ������ �⺻�� �Է�
                if (string.IsNullOrEmpty(deviceName))
                {
                    deviceName = "��ġ�̸��Է�";
                }
                // ���ø� ���� ��ο� ���� ���� ���
                string templatePath = Path.Combine(installFolder, "frpc_template.ini");
                string finalPath = Path.Combine(installFolder, "frpc.ini");
                // ���ø� ������ �о�� �Է¹��� ��ġ���� ���Ͽ� ġȯ
                string content = File.ReadAllText(templatePath);
                content = content.Replace("[devicename]", $"[{deviceName}]");
                // UTF-8 ���ڵ����� ���� �ۼ�
                // File.WriteAllText(finalPath, content, Encoding.UTF8); // UTF-8 with BOM
                File.WriteAllText(finalPath, content, new UTF8Encoding(false)); // UTF-8
                // ��� ��ȯ
                return ActionResult.Success;
            }
            catch (Exception ex)
            {
                // ���� �߻� �� ����ó��
                session.Log("ERROR in ReplaceDeviceNameInIni: " + ex.ToString());
                return ActionResult.Failure;
            }
        }
    }
}
