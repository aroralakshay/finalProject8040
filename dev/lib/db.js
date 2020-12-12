var mysql=require('mysql');

function handleDisconnect() {
  var connection=mysql.createConnection({
    host:'localhost',
    user:'root',
    password:'123456',
    database:'seng8040'
  });
  connection.connect(function(err) {              
      if(err) {                     
          console.log('error when connecting to db:', err);
          setTimeout(handleDisconnect, 2000); 
      }                                
  });                             
  connection.on('error', function(err) {
      console.log('db error', err);
      if(err.code === 'PROTOCOL_CONNECTION_LOST') { 
          console.log('FIXING PROTOCOL_CONNECTION_LOST')
          handleDisconnect();              
      } else {              
          throw err;      
      }
  });
  return connection;
}

var connection = handleDisconnect();
module.exports = connection; 