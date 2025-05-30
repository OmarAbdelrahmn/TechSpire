﻿namespace TechSpire.infra.Settings;

public class MailSettings
{
    public string Host { get; set; } = string.Empty;
    public int Port { get; set; }
    public string Password { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;

    public string Mail { get; set; } = string.Empty;

}
