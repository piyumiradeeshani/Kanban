
This API project design and implement of some features of a kanban board with .Net5 and Entity framework core.

API Details

Assuming the JWT token which is server sent after the login is attached to the Authorization header in every request.
Body parameters can be sent as application/json
Please enter the Username = “Ann” and Email = “ann@gmail.com” to Users table as initially API get “Ann” as the logged user.
Also for the Status table add StatusType=”Open”, StatusType=”InProgress” etc and for the Tag table Tagname=“High”, Tagname= “Low” etc

End Points

1. Create Board : api/v1/board : POST 

2. Edit Board :  api/v1/board/{id} :  PUT 

3. Delete Board : api/v1/board/{id} :  DELETE 

4. Create task : api/v1/board/{board_id}/task :  POST 
 
5. Edit task : api/v1/board/{board_id}/task/{task_id} : PUT 

6. Delete task : api/v1/board/{board_id}/task/{task_id} : DELETE 

7. Get board and task list : api/v1/board/tasks : GET

8. Board are created by a user : api/v1/user/{id}/boards : GET 

9. Creater invite other users to the board : api/v1/board/{id}/users : POST 

10 One ormore user can be assigned to a task : api/v1/board/{board_id}/task/{task_id}/users : POST 
