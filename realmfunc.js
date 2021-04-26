//Send Stuff
//https://webhooks.mongodb-realm.com/api/client/v2.0/app/xx/service/xx/incoming_webhook/xx

exports = async function(payload, response) {

    console.log("Adding Info...");
    const path =  context.services.get("mongodb-atlas").db("scoreDB").collection("scoreCollection");

    // parse the body to get the tag
    const info = EJSON.parse(payload.body.text());

    return path.insertOne(info);

};
