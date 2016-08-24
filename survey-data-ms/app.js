var seneca = require("seneca")();

seneca.use("mongo-store", {
    uri: "mongodb://<dbuser>:<dbpassword>@ds044229.mlab.com:44229/survey"
});

seneca.add({role: "survey-data", cmd: "save"}, function (args, respond) {
    var surveys = seneca.make$("surveys");

    var data = surveys.data$(args.survey);

    data.save$(function (err, entity) {
        if (err) return respond(err);

        respond(null, {value: true});
    })
});

seneca.add({role: "survey-data", cmd: "count"}, function (args, respond) {
    var surveys = seneca.make$("surveys");

    surveys.native$(function (err, db) {

        db.collection('surveys').count({}, function (err, result) {
            if (err) return respond(err);

            respond(null, {"count": result});
        });

        respond(null, {"count": count});
    })
});

seneca.listen({port: process.env.PORT});