This is the Core Couchbase Lite library.  All of the Couchbase Lite features, aside from its REST API and Multicast DLL abilities, are implemented here.  This means that if you are using Couchbase Lite, you will be using this.  Here is a rundown of the files:

Couchbase.Lite.dll - All of the Couchbase Lite functionality is implemented here, the other files here simply support it
ICSharpCode.SharpZipLib.dll - Used for ZIP support (I had problems with DeflateStream on Unity's runtime)
Newtonsoft.Json.dll - JSON serialization / deserialization library
Rackspace.Threading.dll / System.Threading.Tasks.Net35.dll - Task Parallel Library for .NET 3.5
System.Net.Http.Net35.dll - System.Net.Http namespace for .NET 3.5
ugly_net35.dll - .NET 3.5 implementation of SQLitePCL.Ugly
SQLitePCL.raw.dll - Until I can figure out how to make Unity honor dll.config files, these are split by platform.  C# bindings and marshalling logic for interaction with native sqlite library
sqlite3.dll - Native Windows DLL for sqlite

The SQLitePCL.raw library not in a platform folder may be used for any Unity standalone target.  The one in the iOS folder is for iOS, and the one in the Android folder is for Android.  Furthermore, on Windows you must include the proper native sqlite3.dll in your project since it is not installed by default.  Just maintain the structure in this zip.  You can verify the checksums of the files with the *nix command:

shasum -c checksums.txt
