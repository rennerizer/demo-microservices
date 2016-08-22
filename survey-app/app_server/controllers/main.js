/* GET 'survey' page */
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