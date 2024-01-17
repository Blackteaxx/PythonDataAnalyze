
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using IS.Forms;
using IS.Forms.User;
using IS.Services;
namespace IS;

public partial class Upload : Form
{
    static string downloadrelativePath = "..\\..\\..\\Resource\\download\\";
    string downloadFolderPath = Path.GetFullPath(Path.Combine(Application.StartupPath, downloadrelativePath));
    static string uploadrelativePath = "..\\..\\..\\Resource\\yunpan\\";
    string folderPath = Path.GetFullPath(Path.Combine(Application.StartupPath, uploadrelativePath));

    // �������ݿ�
    /*private string connectionString = "Server = 101.43.94.40,5000; " +
    "Database = web; " +
    "uid = web; pwd = 202!@#QWEasd; " +
    "TrustServerCertificate=true;";*/ // ���ݿ������ַ���ģ��

    // ʹ�ñ��ص����ݿ�
    private static readonly string connectionString =
        "Server = localhost; " +
        "Database = web; " +
        "uid = IS; pwd = 5151; " +
        "TrustServerCertificate=true;";
    private string uploader = Main.uid.ToString();//����Ϊ��¼ʱ��username;

    public Upload()
    {
        Directory.CreateDirectory(folderPath);
        InitializeComponent();
        InitializeDataGridView();
        ///LoadFilesFromDatabase();
    }
    private void InitializeDataGridView()
    {
        // ����DataGridView��
        dataGridView1.Columns.Add("FileName", "�ļ���");
        dataGridView1.Columns.Add("FileType", "�ļ�����");
        dataGridView1.Columns.Add("FileSize", "�ļ���С");
        dataGridView1.Columns.Add("UploadTime", "�ϴ�ʱ��");
        dataGridView1.Columns.Add("Uploader", "�ϴ���");
        dataGridView1.Columns.Add("FilePath", "�ļ�·��");

        // �����û����б�������
        dataGridView1.Columns["FileSize"].SortMode = DataGridViewColumnSortMode.Automatic;
        dataGridView1.Columns["UploadTime"].SortMode = DataGridViewColumnSortMode.Automatic;

        // �����û�ѡ�����
        dataGridView1.MultiSelect = true;

        // ���ѡ����
        DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
        checkBoxColumn.HeaderText = "ѡ������";
        checkBoxColumn.Name = "DownloadCheckBox";
        dataGridView1.Columns.Insert(0, checkBoxColumn);

    }
    private void btnSortByTime_Click(object sender, EventArgs e)
    {
        dataGridView1.Sort(dataGridView1.Columns["UploadTime"], ListSortDirection.Ascending);
    }

    private void btnSortBySize_Click(object sender, EventArgs e)
    {
        dataGridView1.Sort(dataGridView1.Columns["FileSize"], ListSortDirection.Ascending);
    }

    private void btnReload_Click(object sender, EventArgs e)
    {
        LoadFilesFromDatabase();
    }
    private void LoadFilesFromDatabase()
    {
        try
        {

            // ����������ŶӺŻ���˺Ź��������ַ���
            string teamNumber = txtTeamNumber.Text;
            string personalNumber = txtPersonalNumber.Text;

            // ��ѯ���ݿⲢ�����ļ��б�
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query;
                SqlCommand command;

                if (!string.IsNullOrEmpty(teamNumber))
                {
                    query = "SELECT FileName, FileType, FileSize, UploadTime, Uploader,FilePath FROM [File] WHERE teamNumber = @teamNumber";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@teamNumber", teamNumber);
                }
                else if (!string.IsNullOrEmpty(personalNumber))
                {
                    query = "SELECT Filename,FileType, FileSize, UploadTime, Uploader,FilePath FROM [File] WHERE personalNumber = @personalNumber";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@personalNumber", personalNumber);
                }
                else
                {
                    MessageBox.Show("�������ŶӺŻ��߸��˺�");
                    return;
                }


                using (SqlDataReader reader = command.ExecuteReader())
                {
                    dataGridView1.Rows.Clear();

                    while (reader.Read())
                    {
                        int index = dataGridView1.Rows.Add();
                        dataGridView1.Rows[index].Cells["FileName"].Value = reader["FileName"].ToString();
                        dataGridView1.Rows[index].Cells["FileType"].Value = reader["FileType"].ToString();
                        dataGridView1.Rows[index].Cells["FileSize"].Value = reader["FileSize"].ToString();
                        dataGridView1.Rows[index].Cells["UploadTime"].Value = reader["UploadTime"].ToString();
                        dataGridView1.Rows[index].Cells["Uploader"].Value = reader["Uploader"].ToString();
                        dataGridView1.Rows[index].Cells["FilePath"].Value = reader["FilePath"].ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("�����ļ�ʧ��: " + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }


    private void btnUpload_Click(object sender, EventArgs e)
    {
        string teamNumber = txtTeamNumber.Text;
        string personalNumber = txtPersonalNumber.Text;
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = Path.GetFileName(filePath);

                try
                {
                    // ���ļ����Ƶ������ļ���
                    string localFolderPath = folderPath; // �滻Ϊ��ı����ļ���·��
                    string localFilePath = Path.Combine(localFolderPath, fileName);

                    File.Copy(filePath, localFilePath);

                    // �������ݿ�
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "INSERT INTO [File] (FileName, FileType, FileSize, UploadTime, Uploader, teamNumber,personalNumber, FilePath) " +
                                       "VALUES (@FileName, @FileType, @FileSize, @UploadTime, @Uploader, @teamNumber,@personalNumber, @FilePath)";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@FileName", fileName);
                            command.Parameters.AddWithValue("@FileType", Path.GetExtension(fileName));
                            command.Parameters.AddWithValue("@FileSize", new FileInfo(localFilePath).Length);
                            command.Parameters.AddWithValue("@UploadTime", DateTime.Now);
                            command.Parameters.AddWithValue("@Uploader", uploader); // �滻Ϊ��ǰ�û�
                            command.Parameters.AddWithValue("@TeamNumber", teamNumber);
                            command.Parameters.AddWithValue("@personalNumber", personalNumber);
                            command.Parameters.AddWithValue("@FilePath", localFilePath);

                            command.ExecuteNonQuery();
                        }
                    }

                    // ˢ��DataGridView
                    LoadFilesFromDatabase();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("�ϴ��ļ�ʧ��: " + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void btnDownload_Click(object sender, EventArgs e)
    {
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            bool isSelected = Convert.ToBoolean(row.Cells["DownloadCheckBox"].Value);

            if (isSelected)
            {
                try
                {
                    string fileName = row.Cells["FileName"].Value.ToString();

                    string filePath = uploadrelativePath + fileName;

                    string localFilePath1 = Path.Combine(downloadFolderPath, fileName);

                    File.Copy(filePath, localFilePath1, true);

                    MessageBox.Show($"�ļ� {fileName} ���سɹ���", "�ɹ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("�����ļ�ʧ��: " + ex.Message, "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void backtomain_Click(object sender, EventArgs e)
    {
        //������һ��

    }
}
