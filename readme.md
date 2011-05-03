OnChange

OnChange is a console line tool for Windows that can will watch for file changes in the current directory and execute an action (another program) as files change.

OnChange can also be configured to do reactions based on the output of the action. That is if a regex matches on the output of the Action a Reaction will fire (another program)


Currently this is the usage:
onchange.exe -f *.doc -r .*Failed.*:uploadfailed.bat upload.bat

this will watch the current directory for changes to *.doc files. When they change upload.bat will be executed as the action. If the output for upload.bat contains the word "Failed" the uploadfailed.bat will be fired as reaction.
