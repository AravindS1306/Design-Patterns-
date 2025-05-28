public class DVDPlayer
{
    public void On() => Console.WriteLine("DVD Player is ON");
    public void Play() => Console.WriteLine("DVD Player is PLAYING");
}

public class Projector
{
    public void On() => Console.WriteLine("Projector is ON");
    public void SetInput(string source) => Console.WriteLine($"Projector input set to {source}");
}

public class SurroundSoundSystem
{
    public void On() => Console.WriteLine("Surround Sound System is ON");
    public void SetVolume(int level) => Console.WriteLine($"Volume set to {level}");
}

public class Lights
{
    public void Dim() => Console.WriteLine("Lights are DIMMED");
}


// Facade class
public class HomeTheaterFacade
{
    private readonly DVDPlayer _dvdPlayer;
    private readonly Projector _projector;
    private readonly SurroundSoundSystem _soundSystem;
    private readonly Lights _lights;

    public HomeTheaterFacade(DVDPlayer dvdPlayer, Projector projector, SurroundSoundSystem soundSystem, Lights lights)
    {
        _dvdPlayer = dvdPlayer;
        _projector = projector;
        _soundSystem = soundSystem;
        _lights = lights;
    }

    public void StartMovie()
    {
        Console.WriteLine("Get ready to watch a movie...");
        _lights.Dim();
        _soundSystem.On();
        _soundSystem.SetVolume(20);
        _projector.On();
        _projector.SetInput("DVD");
        _dvdPlayer.On();
        _dvdPlayer.Play();
    }
}

class Program
{
    static void Main()
    {
        var dvdPlayer = new DVDPlayer();
        var projector = new Projector();
        var soundSystem = new SurroundSoundSystem();
        var lights = new Lights();

        var homeTheater = new HomeTheaterFacade(dvdPlayer, projector, soundSystem, lights);
        homeTheater.StartMovie();
    }
}

//The Facade Pattern provides a simple interface to a complex subsystem. It helps to hide the complexities of the system and expose only what is necessary.
//This is used in most cases where you get data from 3rd party dll's the 3rd party company will give you a set of interface
//in which you can access the systems data without showing the implementation
//Other cases if you have a complex subsystem, you can hide it by using facade pattern and expose interfaces to 
//functionality that needs this.