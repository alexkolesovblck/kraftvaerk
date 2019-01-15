# kraftvaerk

# Steps:
* Open browser;
* Navigate to "https://google.com";
* Search for "yandex.ru";
* Verify that first result (advertisements shouldn't be considered as search results) has a link which leads to "yandex.ru". 

# Instruction
1. Download the project form github;
2. Open the project in VS;
3. Click "Clean solution";
4. Click "Build solution";
5. After successful building, open windows command line like "cmd.exe";
6. Input in command line "cd PATH/kraftvaerk\Autotests\packages\NUnit.ConsoleRunner.3.9.0\tools>" and then "nunit3-console.exe 'samePATH/kraftvaerk\Autotests\Tests\bin\Debug\Tests.dll'" and click "Enter";
7. Result complete of the test would be a present on command line tab.

P.S. If building was FAIL, open manage NuGet, to update all packages and install them if they are not was download early
