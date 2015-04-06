# FlyoutHelperTest
To repro this issue follow this steps:

1. Start the app (Windows 8.1)
2. Click a button - than click edit and edit the text.
3. Click "Save".
4. Click the same button as in step 2. and try to edit.
5. An exception occures

<code>An exception of type 'System.ArgumentException' occurred in FlyoutProblem.Windows.exe but was not handled in user code WinRT information: Placement target needs to be in the visual tree.
Additional information: Falscher Parameter.</code>
