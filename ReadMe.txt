acTelerikStylesRenaming (18.10.2013), v1.1
Copyright (c) 2013 acDevSoftware

Create a new Telerik Skin by copying and renaming a base Telerik Skin.
This application copies and renames all directories, sub directories and all accepted files
including CSS file from the base Telerik Skin directory to the new one.
In each CSS file, it replaces base Skin name with the new one (Lite version taken in account).


Any questions about the acTelerikStylesRenaming:
supports@acdevsoftware.ch?subject=[acTelerikStylesRenaming]
Or:  
http://www.acdevsoftware.ch/Supports/CustomersService/Default.aspx?cat=TOOLS&sct=GSUP

LinkedIn:
Follow the product news on LinkedIn:
http://www.linkedin.com/company/acdevsoftware/actelerikstylesrenaming-21787421/product?trk=biz_product

Facebook:
https://www.facebook.com/pages/Acdevsoftware/1375578242656685


Indexes:
A. Dependencies.
B. Installation.
C. Usage.
D. Confirguration of acTelerikStylesRenaming with acTelerikStylesRenaming.exe.config.
E. Compatibility with Telerik StyleBuilder application.
F. History.


A. Dependencies

acTelerikStylesRenaming needs:
- Framework .NET 4.0
- Visual Studio 2010 or newer for compiling the source code.


B. Installation

Install with the installer and all is ready to use.


C. Usage

1. Launch acTelerikStylesRenaming
2. Set the Skin Directory field to the Telerik Skin directory to be copied and renamed.
   Example to copy Black Skin:
   C:\Program Files\Telerik\RadControls for ASP.NET AJAX Q2 2013\Skins\Black
3. Set the New Skin Name field to the new name (if the Skin Directory, point 2, is the Lite
   version, the new name is automatically appended with Lite word.
   Example: MyBlack
   Example with Lite: MyBlackLite
4. Set the Output Directory field to the directory where the new Skin will be created.
   acTelerikStylesRenaming will create a sub directory containing the new Skin.
   Example: C:\Temp will contain C:\Temp\MyBlack
5. Set New Skin Zipped to true to generate the zipped file of the new generated Skin.
   This zipped Skin file can be used by our tool acTelerikStylesAssembly or
   Telerik StyleBuilder (see index E)
6. Click on the button "Generate New Skin" and if no error occurs, the new Telerik Skin
   is created from Skin Directory (point 2) into the Output Directory (point 4).
   Example: C:\Temp\MyBlack
7. If New Skin Zipped was set to true, the new Telerik Skin is zipped with the new Skin Name
   appended with zip extension into the Output Directory (point 4).


D. Configuration of acTelerikStylesRenaming with acTelerikStylesRenaming.exe.config

1. Set TelerikSkinsPath setting to the path of the Telerik Skins directory and
   the Skin Directory field will be filled with this value at startup.
2. AssemblyCulture setting is not used currently.


E. Compatibility with Telerik StyleBuilder application

The current version of Telerik StyleBuilder (28.03.2013, http://stylebuilder.telerik.com)
doesn't accept the generated zipped New Skin file (example with MyBlack) because
RadAjax_MyBlack.css and RadAsyncUpload_MyBlack.css containing in this zipped file crash
the StyleBuilder application (The same problem occurs if an original skin from Skins folder
is zipped and loaded in StyleBuilder).

As a workaround, extract and remove the two files RadAjax_MyBlack.css and
RadAsyncUpload_MyBlack.css from MyBlack.zip, load the NewSkin.zip in Telerik StyleBuilder
and after saving it, put back the two extracted files RadAjax_MyBlack.css and
RadAsyncUpload_MyBlack.css in MyBlack.zip.


F. History

1.0.0 (09.09.2013):

Initial release

1.1.0:

Fix:
- The Common Telerik Skins folder and all its contents was not copied into the Common folder
  of the new generated skin folder.

New:
- Added the possibility to zip the new generated Skin folder to be used directly by
  acTelerikStylesAssembly or Telerik StyleBuilder Web Application.
