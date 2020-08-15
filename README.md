# Sector Builder

Sector Builder is a command line tool to put split EuroScope sector files together.


### Usage

```
<FILE_LIST> [--output-name <OUTPUT_NAME>] [--output-dir <OUTPUT_DIRECTORY>] [--insert-sources] [--verbose]
```

### Arguments

##### <FILE_LIST>

Path to the file list. The file list format will be described below.

##### --output-name <OUTPUT_NAME>

The name of output sector files (sct and ese). For example, if you pass "ZBPE", the output will be "ZBPE.sct" and "ZBPE.ese".

The default value is ```a```.

##### --output-dir <OUTPUT_DIRECTORY>

The directory where sector files will be built.

The default path is ```./.build```. 

##### --insert-sources

Appends source file info to output sector files.

##### --verbose

Increases logging verbosity for debugging purposes.

### File List Format

File list is a json containing file paths. These paths are based on the directory where the file list is.

When you are writing a file list, you need to put paths into different arrays. Each array has a corresponding sector section, and Sector Builder will put the content of every file in an array into the corresponding sector section. The corresponding relationship defined by Sector Builder is listed below.

You may use paths with glob expressions as well. For the supported glob expressions, please visit the readme of [kthompson/glob](https://github.com/kthompson/glob), the glob library that Sector Builder is using.

| Array Name | To Section | To File |
| ------- | ------- | --- |
| color | - | sct |
| info | INFO | sct |
| airport | AIRPORT | sct |
| runway | RUNWAY | sct |
| vor | VOR | sct |
| ndb | NDB | sct |
| fix | FIXES | sct |
| highAirway | HIGH AIRWAY | sct |
| lowAirway | LOW AIRWAY | sct |
| sid | SID | sct |
| star | STAR | sct |
| artcc | ARTCC | sct |
| artccHigh | ARTCC HIGH | sct |
| artccLow | ARTCC LOW | sct |
| label | LABELS | sct |
| geo | GEO | sct |
| region | REGIONS | sct |
| position | POSITIONS | ese |
| freetext | FREETEXT | ese |
| sidstar | SIDSSTARS | ese |
| airspace | AIRSPACE | ese |
| radar | RADAR | ese |
| ground | GROUND | ese |



##### Example

```json
{
    "info": [
        "Info.txt"
    ],
    "airport": [
        "Airports/*.txt"
    ],
    "runway": [
        "Runways/ZSSS.txt",
        "Runways/ZSPD.txt",
        "Runways/ZSNJ.txt"
    ]
}
```

