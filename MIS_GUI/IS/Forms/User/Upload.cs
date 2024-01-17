
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

    // 云上数据库
    /*private string connectionString = "Server = 101.43.94.40,5000; " +
    "Database = web; " +
    "uid = web; pwd = 202!@#QWEasd; " +
    "TrustServerCertificate=true;";*/ // 数据库连接字符串模板

    // 使用本地的数据库
    private static readonly string connectionString =
        "Server = localhost; " +
        "Database = web; " +
        "uid = IS; pwd = 5151; " +
        "TrustServerCertificate=true;";
    private string uploader = Main.uid.ToString();//更换为登录时的username;

    public Upload()
    {
        Directory.CreateDirectory(folderPath);
        InitializeComponent();
        InitializeDataGridView();
        ///LoadFilesFromDatabase();
    }
    private void InitializeDataGridView()
    {
        // 设置DataGridView列
        dataGridView1.Columns.Add("FileName", "文件名");
        dataGridView1.Columns.Add("FileType", "文件类型");
        dataGridView1.Columns.Add("FileSize", "文件大小");
        dataGridView1.Columns.Add("UploadTime", "上传时间");
        dataGridView1.Columns.Add("Uploader", "上传人");
        dataGridView1.Columns.Add("FilePath", "文件路径");

        // 允许用户按列标题排序
        dataGridView1.Columns["FileSize"].SortMode = DataGridViewColumnSortMode.Automatic;
        dataGridView1.Columns["UploadTime"].SortMode = DataGridViewColumnSortMode.Automatic;

        // 允许用户选择多行
        dataGridView1.MultiSelect = true;

        // 添加选择列
        DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
        checkBoxColumn.HeaderText = "选择下载";
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

            // 根据输入的团队号或个人号构建连接字符串
            string teamNumber = txtTeamNumber.Text;
            string personalNumber = txtPersonalNumber.Text;

            // 查询数据库并加载文件列表
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
                    MessageBox.Show("请输入团队号或者个人号");
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
            MessageBox.Show("加载文件失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    // 将文件复制到本地文件夹
                    string localFolderPath = folderPath; // 替换为你的本地文件夹路径
                    string localFilePath = Path.Combine(localFolderPath, fileName);

                    File.Copy(filePath, localFilePath);

                    // 更新数据库
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
                            command.Parameters.AddWithValue("@Uploader", uploader); // 替换为当前用户
                            command.Parameters.AddWithValue("@TeamNumber", teamNumber);
                            command.Parameters.AddWithValue("@personalNumber", personalNumber);
                            command.Parameters.AddWithValue("@FilePath", localFilePath);

                            command.ExecuteNonQuery();
                        }
                    }

                    // 刷新DataGridView
                    LoadFilesFromDatabase();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("上传文件失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    MessageBox.Show($"文件 {fileName} 下载成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("下载文件失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void backtomain_Click(object sender, EventArgs e)
    {
        //返回上一级

    }
}
