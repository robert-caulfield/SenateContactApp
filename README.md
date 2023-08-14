# SenateContactApp
This is a C# .NET WPF application that fetches a list of senators from an XML file on the senator.gov website and displays them in a listbox. The application follows the Model-View-ViewModel (MVVM) architecture for separation of concerns. It allows users to filter the list of senators based on state and senator name. Users can click on a senator's entry in the listbox to view their contact information. The app retrieves senator data asynchronously to ensure that the GUI remains responsive even if there are problems or slow data retrieval.

## Features
- Fetches a list of senators from an XML file on the senator.gov website.
- Displays the list of senators in a customizable listbox.
- Allows filtering senators by state and senator name.
- Displays senator contact information when a senator's entry is clicked.
- Asynchronous data retrieval to prevent GUI slowdowns.
- Follows the Model-View-ViewModel (MVVM) architecture.

## Technologies used
- C# .NET (WPF) for the GUI application.
- Asynchronous programming for responsive data retrieval.
- Senator data downloaded and deserialized from an XML file on the senate.gov website.
- Model-View-ViewModel (MVVM) architecture for clear separation of concerns.

## Acknowledgments
- Senator data sourced from senate.gov.
- Inspired by the need to provide an efficient and user-friendly way to access senator information.
