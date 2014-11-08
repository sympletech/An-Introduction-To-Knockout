var restify = require('restify'),
    _ = require('lodash');

var server = restify.createServer();
server.use(restify.fullResponse());
server.use(restify.bodyParser());
server.use(restify.gzipResponse());

server.get('/', function(req, res, next){
    res.send('An API');
});



var cars = [
    { id: _.uniqueId(), car: "Ford Mustang", speed: 160 },
    { id: _.uniqueId(), car: "Chevy Camaro", speed: 220 },
    { id: _.uniqueId(), car: "Dodge Dart", speed: 140 },
    { id: _.uniqueId(), car: "Acura Integra", speed: 195 },
    { id: _.uniqueId(), car: "VW Love Bus", speed: 45 }
];

server.get('/cars', function(req, res){
    res.send(cars);
});

server.post('/cars', function(req, res){
    var itemToSave = JSON.parse(req.params.payload);
    itemToSave.id = _.uniqueId();
    cars.push(itemToSave);
    res.send('complete');
});

server.del('/cars/:id', function(req, res){
    _.remove(cars, function(car){
        return car.id == req.params.id;
    });

    res.send('complete');
});



server.listen(5150, function () {
    console.log('%s listening at %s', server.name, server.url);
});