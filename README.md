# Iron Tracks
Iron Tracks is a deck tracker for the Pokemon Trading Card Game Live, whose goal is to allow players to easily keep track of their deck resources in-game with live UI.
Iron Tracks is a Unity Mod using MelonLoader API to load the modules into the game. Don't waste time taking notes of what's prized, and being able to have complete knowledge of your deck resources without the need for external notes!
**Please Read Disclaimer** about Iron Tracks below!!

# Installation
1. Navigate to the [Releases](https://github.com/Bratah123/IronTracks/releases) Page.

   ![image](https://github.com/Bratah123/IronTracks/assets/58405975/7df72072-6bca-4833-9bd6-046b4fa24807)

2. Download the latest version zip in the Release Page.

   ![image](https://github.com/Bratah123/IronTracks/assets/58405975/d877e7b2-9a2b-4811-9402-952b5df53c73)

3. Open up `IronTracks.zip` (Note that inside the zip you should see a `IronTracks` folder) extract all the contents of `IronTracks` folder (not to be confused with the .zip) into your PTCGL's client's folder.

   ![image](https://github.com/Bratah123/IronTracks/assets/58405975/790d7087-eea0-4d80-9ddc-3473650bf600)

4. Press Z/X in-game to toggle the Deck Tracker UI!

# Controls
- Press Z to enable the Deck Tracker
- Press X to enable the Prize Tracker
- Press V to toggle the Action Advisor overlay

# Gallery
![Pre Deck Search](https://github.com/Bratah123/IronTracks/assets/58405975/0b6e2704-aedb-479f-b735-dcf4382e95c7)
![Post Deck Search](https://github.com/Bratah123/IronTracks/assets/58405975/56a0d6b8-02cd-4521-a57e-29ca76cecf30)

# Building From Source
Iron Tracks targets **.NET 8**. Install the [.NET 8 SDK](https://learn.microsoft.com/dotnet/download)
to build the tracker and run the tests.

Cross‑platform builds are still experimental because the game libraries are
Windows‑only, but targeting .NET 8 allows the project to compile on more
platforms as long as the proprietary dependencies are available.


The project references DLLs from the game's installation folder. Set the
`PTCGL_PATH` MSBuild property to point to your copy of *Pokemon TCG Live* so
that the build system can locate these files. You can pass it on the command
line:

```bash
dotnet build -p:PTCGL_PATH="C:\\Games\\Pokemon TCG Live"
```

Or create a `Directory.Build.props` file in the repository root defining the
`PTCGL_PATH` property for repeated builds.


The GitHub workflow uses an environment variable to provide this path. See
`.github/workflows/dotnet-desktop.yml` for an example.

To build the project you must set the `PTCGL_PATH` environment variable to the
folder containing your PTCGL installation. The build expects to find the
`MelonLoader` directory and the game's `Pokemon TCG Live_Data/Managed` directory
inside this path. For example on Windows this might be:

```
set PTCGL_PATH=E:\PTCGL\Pokemon Trading Card Game Live
```

On other platforms adjust the path accordingly so the libraries can be located
when running `dotnet build`.

# Developer Notes/FAQ
- Q: My MelonLoader isn't loading your mod correctly, how do I fix this?
  - A: The only valid Melon Loader version for the current PTCGL is v0.5.7
- Q: I'm getting error `Failed to Open Mono Assembly`:

![image](https://github.com/Bratah123/IronTracks/assets/58405975/165a0838-21e5-45f9-b255-588e24b1a493)
  - A: This error is caused by the MelonLoader program being unable to read the `é` in the word "Pokémon". This can be fixed by changing your PTCGL client's folder to something else I.E. `PTCGL`

# Disclaimer
Iron Tracks is an open-source Unity Mod that modifies the PTCGL client's game, and serves them to end users as a fully functional deck tracker. Iron Tracks is an educational project for demonstrating various techniques, such as reverse engineering and game modding.
The creators of Iron Tracks urge users and end users of the project, and/or any derivatives of Iron Tracks, to support the creators of PTCGL by purchasing/utilizing their original works, merchandise through official channels. In no way is Iron Tracks trying to provide an unfair advantage to users of the mod, as all game knowledge and data is already known information within the game state. Iron Tracks is non-monetised, and provided as is. Every reasonable effort has been taken to ensure correctness and reliability of Iron Tracks. We will not be liable for any special, direct, indirect, or consequential damages or any damages whatsoever resulting from loss of use, data or profits, whether in an action if contract, negligence or other tortious action, arising out of or in connection with the use of Iron Tracks (in part or in whole).
