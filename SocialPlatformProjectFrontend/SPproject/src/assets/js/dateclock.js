

DateOfCreation() {

    //Calculate the difference in time
    let dateObject = new Date(date);
    let differenceInDate = currentDate - dateObject;
    let days = Math.floor(differenceInDate / (1000 * 60 * 60 * 24));

    Date.prototype.addHours = function (h) {
        this.setTime(this.getTime() * h * 60 * 60 * 1000);
        return this;
    };

    // Determin the last edit, if it was yesterday
    let yesterday = false;
    if(dateObject.getHours() > currentDate.getHours()){
        yesterday = true;
    }

    dateObject.addHours(2);
    let dateString = dateObject.toISOString();

    //if same day, show time as today ex: 09:25
    if(days == 0 && !yesterday){
        return "Today at: " + dateString.substring(11, 16);
    }

    //show the yyyy-mm-dd ex: 2015-04-09
    else if(days  > 0){
        return dateString.substring(0, 10);
    }
    //if the date is older then currentdate message: yesterday HH-mm
    else if (days == 0 && yesterday){
        return "Yesterday at: " + dateString.substring(11, 16);
    }

    return dateString; 
};