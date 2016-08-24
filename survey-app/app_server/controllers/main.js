var seneca = require("seneca")();

seneca.client({host: "url.rennerizer.com", port: 80, pin: {role: "survey-urls"}});
seneca.client({host: "data.rennerizer.com", port: 80, pin: {role: "survey-data"}});
seneca.client({host: "core.rennerizer.com", port: 80, pin: {role: "survey-event"}});

/* GET 'home' page */
module.exports.survey = function(req, res) {
    res.render('survey-form', {
        title: 'Survey for Microservices workshop presentation',
        pageHeader: {
            title: 'Microservices Survey'
        }
    });
};

/* GET 'about' page */
module.exports.about = function(req, res) {
    res.render('about', {
        title: 'About Survey App',
        content: 'This survey application was written using Node.js and Express.'
    });
};

/* POST 'survey' page */
module.exports.submit = function(req, res) {

    var survey = req.body;

    // Save the survey
    seneca.act({role: "survey-data", cmd: "save", survey, function (err, result) {
        // TODO: handle errors
    }});

    // Create survey creation event
    var surveyevent = {
        "role" : "survey-event",
        "cmd" : "fire",
        "eventinfo" : "event details" // TODO include eventid and mongo generated id
    }
    
    // Fire the event
    seneca.act({role: "survey-event", cmd: "fire", surveyevent, function (err, result) {
        // TODO: handle errors
    }});

    res.render('thank-you', {
        title: 'Thank You!',
        content: 'Your feedback is appreciated.'
    });
};