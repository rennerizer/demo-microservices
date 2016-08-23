var seneca = require("seneca")();

seneca.add({role: "survey-urls", cmd: "data"}, function(args, respond){
	respond(null, {value: "data.rennerizer.com"});
});

seneca.add({role: "survey-urls", cmd: "event"}, function(args, respond){
	respond(null, {value: "event.rennerizer.com"});
});

seneca.listen({port: process.env.PORT});