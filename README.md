# pdf-processor
## Information
Currently in version 1.5

A simple PDF manipulator with four features:
- Converting an image to a PDF
- Combining multiple PDFs
- Rotating specific pages
- Compressing PDFs (only works on those with large images)

Running the .exe opens a simple GUI.
Only compatible with Windows 10.

## Building
If you want to build this yourself, I used Visual Studio.
The program relies in GhostScript for compression, so download the Win64 version and put the gs9.54.0 folder from \Program Files in the directory where the output files are, as can be seen in the release. (I know, it's not very pretty.)
