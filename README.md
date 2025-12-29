# SP2-Notification-Library
 #### A notification library for SimplePlanes2

 <img width="682" height="290" alt="image" src="https://github.com/user-attachments/assets/da8fe339-8966-4b63-9d89-99bdd33035c0" />

 ## Usage 

SP2 Notification Library takes 3 arguments: `sender` `message` `duration`

`sender` is used for what mod sent the message
`message` is the message that is displayed
`duration` is how long that message is displayed for

### Example code:

```
void SendNotification()
   {
       Notification.Notification.Show("ExampleMod", "This is an example message", 3f);
   }
```




