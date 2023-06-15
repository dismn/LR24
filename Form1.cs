using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace LR24
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource[] cancellationTokenSources;
        public Form1()
        {
            InitializeComponent();
            // Ініціалізація масиву CancellationTokenSource для кожного алгоритму
            cancellationTokenSources = new CancellationTokenSource[3];
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async Task RunCrabEncryption(CancellationToken cancellationToken)
        {
            try
            {
                Random random = new Random();
                StringBuilder plaintextBuilder = new StringBuilder();

                while (!cancellationToken.IsCancellationRequested)
                {
                    // Генерування випадкової букви (від 'A' до 'Z')
                    char randomLetter = (char)('A' + random.Next(26));

                    plaintextBuilder.Append(randomLetter);

                    int shift = 3; // Зсув
                    string plaintext = plaintextBuilder.ToString();
                    string encryptedText = CRABCipher.Encrypt(plaintext, shift);

                    // Виконання оновлення richTextBox1 з основного потоку
                    richTextBox1.BeginInvoke(new Action(() =>
                    {
                        richTextBox1.Text = encryptedText;
                    }));

                    await Task.Delay(100, cancellationToken); // Приклад асинхронної операції
                }
            }
            catch (TaskCanceledException)
            {
                // Операція скасована
            }
        }

        private async Task RunHillEncryption(CancellationToken cancellationToken)
        {
            try
            {
                Random random = new Random();
                StringBuilder plaintextBuilder = new StringBuilder();

                while (!cancellationToken.IsCancellationRequested)
                {
                    // Генерування випадкової букви (від 'A' до 'Z')
                    char randomLetter = (char)('A' + random.Next(26));

                    plaintextBuilder.Append(randomLetter);

                    string plaintext = plaintextBuilder.ToString();
                    string key = "KEY"; //  ключ HillCipher
                    string encryptedText = HillCipher.HillEncrypt(plaintext, key);

                    // Виконання оновлення richTextBox2 з основного потоку
                    richTextBox2.BeginInvoke(new Action(() =>
                    {
                        richTextBox2.Text = encryptedText;
                    }));

                    await Task.Delay(100, cancellationToken); // Приклад асинхронної операції
                }
            }
            catch (TaskCanceledException)
            {
                // Операція скасована
            }
        }
        private async Task RunBaconEncryption(CancellationToken cancellationToken)
        {
            try
            {
                Random random = new Random();
                StringBuilder plaintextBuilder = new StringBuilder();

                while (!cancellationToken.IsCancellationRequested)
                {
                    // Генерування випадкової букви (від 'A' до 'Z')
                    char randomLetter = (char)('A' + random.Next(26));

                    plaintextBuilder.Append(randomLetter);

                    string plaintext = plaintextBuilder.ToString();
                    string encryptedText = BaconCipher.Encrypt(plaintext);

                    // Виконання оновлення richTextBox3 з основного потоку
                    richTextBox2.BeginInvoke(new Action(() =>
                    {
                        richTextBox3.Text = encryptedText;
                    }));

                    await Task.Delay(100, cancellationToken); // Приклад асинхронної операції
                }
            }
            catch (TaskCanceledException)
            {
                // Операція скасована
            }
        }



        private async void start1_Click(object sender, EventArgs e)
        {
            cancellationTokenSources[0] = new CancellationTokenSource();
            await Task.Run(() => RunCrabEncryption(cancellationTokenSources[0].Token));
        }

        private void stop1_Click(object sender, EventArgs e)
        {
            cancellationTokenSources[0]?.Cancel();
        }

        private async void  start2_Click(object sender, EventArgs e)
        {
            cancellationTokenSources[1] = new CancellationTokenSource();
            await Task.Run(() => RunHillEncryption(cancellationTokenSources[1].Token));
        }

        private void stop2_Click(object sender, EventArgs e)
        {
            cancellationTokenSources[1]?.Cancel();
        }

        private async void start3_Click(object sender, EventArgs e)
        {
            cancellationTokenSources[1] = new CancellationTokenSource();
            await Task.Run(() => RunBaconEncryption(cancellationTokenSources[1].Token));
        }

        private void stop3_Click(object sender, EventArgs e)
        {
            cancellationTokenSources[1]?.Cancel();
        }

        private async void startall_Click(object sender, EventArgs e)
        {
            cancellationTokenSources[0] = new CancellationTokenSource();
            cancellationTokenSources[1] = new CancellationTokenSource();
            cancellationTokenSources[2] = new CancellationTokenSource();

            Task crabEncryptionTask = Task.Run(() => RunCrabEncryption(cancellationTokenSources[0].Token));
            Task baconEncryptionTask = Task.Run(() => RunBaconEncryption(cancellationTokenSources[1].Token));
            Task hillEncryptionTask = Task.Run(() => RunHillEncryption(cancellationTokenSources[2].Token));

            await Task.WhenAll(crabEncryptionTask, baconEncryptionTask, hillEncryptionTask);
        }

        private void stopall_Click(object sender, EventArgs e)
        {
            cancellationTokenSources[0]?.Cancel();
            cancellationTokenSources[1]?.Cancel();
            cancellationTokenSources[2]?.Cancel();
        }
    
    }
}
