using MovieApp.Properties;
using System.Text.Json;

namespace MovieApp.Forms;

public partial class MainForm : Form
{
    const string _apikey = "580270e";
    const string _url = $"http://www.omdbapi.com/?apikey={_apikey}&";

    public MainForm()
    {
        InitializeComponent();
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
        using HttpClient client = new();

        
        string jsonResult1 = await client.GetStringAsync($"{_url}t=Limitless");
        var movie1 = JsonSerializer.Deserialize<Movie>(jsonResult1);
        pictureBox2.LoadAsync(movie1?.Poster);


        string jsonResult2 = await client.GetStringAsync($"{_url}t=Constantine");
        var movie2 = JsonSerializer.Deserialize<Movie>(jsonResult2);
        pictureBox3.LoadAsync(movie2?.Poster);


        string jsonResult3 = await client.GetStringAsync($"{_url}t=Black Adam");
        var movie3 = JsonSerializer.Deserialize<Movie>(jsonResult3);
        pictureBox4.LoadAsync(movie3?.Poster);

        string jsonResult4 = await client.GetStringAsync($"{_url}t=A-team");
        var movie4 = JsonSerializer.Deserialize<Movie>(jsonResult4);
        pictureBox5.LoadAsync(movie4?.Poster);
    }

    private async void btn_search_Click(object sender, EventArgs e)
    {
        string search = $"{_url}t={txt_search.Text}";
        using HttpClient client = new();


        string jsonResult = await client.GetStringAsync(search);
        var movie = JsonSerializer.Deserialize<Movie>(jsonResult);
        if (movie?.Poster is null || movie.Poster == "N/A")
        {
            pictureBox1.Image = Resources._255_2550411_404_error_images_free_png_transparent_png;
            label1.Text = "Release date : Error";
            label2.Text = "Genre : Error";
            label3.Text = "Country : Error";
            label4.Text = "IMDB : Error";
        }
        else
        {
            pictureBox1.LoadAsync(movie?.Poster);
            label1.Text = $"Release date : {movie?.Released}";
            label2.Text = $"Genre : {movie?.Genre}";
            label3.Text = $"Country : {movie?.Country}";
            label4.Text = $"IMDB : {movie?.imdbRating}";
        }
    }

}
