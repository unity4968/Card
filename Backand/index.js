
// cd YourServerPath
// npm uninstall socket.io
// npm install socket.io@2.1.1

var app=  require('express')();
//const app = express();
 var http = require('http').Server(app);
 var io = require('socket.io')(http);
 app.get('/', function(req, res){
     res.send('<h1>Hello world</h1>')
 });

 //app.use(express.json());
 //app.use(express.urlencoded());
 
 io.on('connection', function(socket){
    

     socket.on('disconnect',function () 
     {
         console.log('User Disconnected...')
         socket.emit('disconn', {"name": "User Disconnected..."});
     });

     socket.on('messages',function (msg) {
          console.log('HELLO');
          console.log(msg);
     });

	 socket.on('vv',function (msg) {
		console.log('its form unity');
		console.log(msg);
		socket.emit('ABC', {"name": "vivek"});
   });
   socket.on('StartCheck',function (msg) 
	 {
		//console.log('call from unity...');
        //const Name = JSON.stringify(msg);
        const x = msg["UserName"];
        console.log(`a user connected ${x}`);
		socket.emit('Conne', msg);
	});

 });

 http.listen(80, function(){
     console.log('listening on *:80');
 });