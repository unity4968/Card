
// cd YourServerPath
// npm uninstall socket.io
// npm install socket.io@2.1.1

var app = require('express')();
 var http = require('http').Server(app);
 var io = require('socket.io')(http);
 
 app.get('/', function(req, res){
     res.send('<h1>Hello world</h1>')
 });
 
 io.on('connection', function(socket){
     console.log('a user connected');

     socket.on('disconnect',function () {
         console.log('User Disconnected...')
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
   socket.on('first',function () 
	 {
		console.log('call from unity...');
		socket.emit('vv', {"name": "rahul"});
	});

 });
 
 
 http.listen(80, function(){
     console.log('listening on *:80');
 });