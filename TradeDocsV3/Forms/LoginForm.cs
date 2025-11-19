using System;
using System.Windows.Forms;
using TradeDocsV3.Data;
using TradeDocsV3.Models;
using TradeDocsV3.Services;

namespace TradeDocsV3.Forms;

public partial class LoginForm : Form
{
    private AppSettings _settings;
    private UserRepository? _userRepo;

    public LoginForm()
    {
        InitializeComponent();
        _settings = ConfigManager.Load();
    }

    private void LoginForm_Load(object sender, EventArgs e)
    {
        _userRepo = new UserRepository(_settings);
        _userRepo.EnsureMssqlTables();
    }

    private void btnLogin_Click(object sender, EventArgs e)
    {
        if (_userRepo == null) return;
        var login = txtLogin.Text.Trim();
        var pass = txtPassword.Text.Trim();

        if (_userRepo.ValidateUser(login, pass, out var role))
        {
            _userRepo.UpdateLastLogin(login);
            var main = new MainForm(login, role, _settings);
            main.Show();
            this.Hide();
        }
        else
        {
            MessageBox.Show("Невірний логін або пароль.");
        }
    }

    private void btnSettings_Click(object sender, EventArgs e)
    {
        using var frm = new SettingsForm(_settings);
        frm.ShowDialog();
        _settings = ConfigManager.Load(); // Перезавантаження після змін
        // Переініціалізація репозиторію, якщо змінилась база
        try { _userRepo = new UserRepository(_settings); } catch { }
    }

    private void btnExit_Click(object sender, EventArgs e) => Application.Exit();
}