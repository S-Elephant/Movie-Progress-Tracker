==============================================================================
=                         Installation Instructions                          =
==============================================================================
- Install the .NET framework 4.0. It is located in this application's main
  folder ("dotNetFx40_Full_setup.exe").
  Alternatively it can be downloaded from here:
  http://www.microsoft.com/en-us/download/details.aspx?id=17851
- Copy and unzip the files and start "MovieProgressTracker.exe".

==============================================================================
=                                    About                                   =
==============================================================================
- This is a very simple and minimalistic application for keeping track what
  movies and series you have already watched. If you are like me and watch 20+
  series and anime at the same time you might not remember what episode you
  watched last.
- I know that there are online solutions but most of them only allow you to
  keep track of movies from a predefined list (like only anime or only
  Hollywood movies).
- You can also doubleclick any green movies in the list to open their
  location. You can set those by adding a value to the "Directory" textbox
  when creating a movie.
- Adding extra seasons and/or episodes to existing movies currently requires
  you to edit the XML. There is no GUI for it (yet).
- It stores all of it's files/profiles in it's main- or sub-directories.
==============================================================================
=                              Help / Extra Info                             =
==============================================================================
- So what if you have an external drive with your movies that has Driveletter
  G:\ on machine X and driveletter H:\ on machine Y?
  Goto <application dir>\Settings\DriveLetterSwaps.txt and add the following
  line (without quotes!): "G;H" (note that this is the same as "H;G"). That's
  it. The application will now swap the drives when it can't find the path on
  a machine. Each line can contain 2 letters seperates by a ";" (without the
  quotes).
- You may delete nodes in the treeview by pressing [Delete] when a node is
  selected. This works for movies, seasons and episodes alike. You may also
  Right-Click the nodes and delete/change their names.
- You can edit the genres by editing <application dir>\Settings\Genres.txt
==============================================================================
=                                   Credits                                  =
==============================================================================
Napoleon: Programming & Design.

Open Clip Art Library (www.openclipart.org): The cancel, check, help and 
executable icons.

==============================================================================
=                                   Changes                                  =
==============================================================================

Version 0.9.0 (August 23 2010):
 - First release
 - This application was created in just a few hours and therefor only contains
   the most basic functions with a quick GUI design.