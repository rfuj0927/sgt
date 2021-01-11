
# Fast CSV Parser

## Usage

    // Init
    CsvParser.RegisterAssembly<Program>();
    
    // Use
    using var parser = new CsvParser(filecontent);
    var header = parser.ReadHeader();
    // or parser.ReadHeader<HeaderModel>()
    var entries = parser.ReadBodyAndMap<MyModel>();
    // or parser.ReadBody(); + parser.Entries
