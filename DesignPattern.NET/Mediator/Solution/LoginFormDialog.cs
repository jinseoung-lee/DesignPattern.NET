﻿using DesignPattern.NET.Mediator.Context;

namespace DesignPattern.NET.Mediator.Solution
{
    class LoginFormDialog : IDialog, IMediator
{
    private CheckBox IsGuest { get; }
    private TextInput Username { get; }
    private TextInput Password { get; }
    private Button Login { get; }
    private Button Cancel { get; }

    public LoginFormDialog()
    {
        IsGuest = new GuestCheckBox();
        Username = new UsernameInput {Mediator = this};
        Password = new PasswordInput {Mediator = this};
        Login = new LoginButton();
        Cancel = new Button();
    }

    public void UpdateChanges()
    {
        Username.Disable = IsGuest.Checked;
        Password.Disable = IsGuest.Checked && !string.IsNullOrEmpty(Username.Value);
        Login.Disable = !IsGuest.Checked && (string.IsNullOrEmpty(Username.Value) || string.IsNullOrEmpty(Password.Value));
    }
}
}