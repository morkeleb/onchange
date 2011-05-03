OnChange
========

Copyright (C) 2011 by Morten Nielsen (http://www.morkeleb.com)

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

Description
-----------

OnChange is a console line tool for Windows that can will watch for file changes in the current directory and execute an action (another program) as files change.

OnChange can also be configured to do reactions based on the output of the action. That is if a regex matches on the output of the Action a Reaction will fire (another program)


Currently this is the usage:
	onchange.exe -f *.doc -r .*Failed.*:uploadfailed.bat upload.bat

another example is:
	onchange -f *.py -r "^FAILED.*$:fail.bat" -r ^OK.*:pass.bat runtests.bat	

this will watch the current directory for changes to *.doc files. When they change upload.bat will be executed as the action. If the output for upload.bat contains the word "Failed" the uploadfailed.bat will be fired as reaction.
