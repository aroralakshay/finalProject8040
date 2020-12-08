var express = require('express');
const { route } = require('.');
var router = express.Router();
var connection  = require('../lib/db');

router.get('/', function(req, res, next) {
        res.render('Sell',{page_title:"Sell - Node.js"});
    }
);

router.get('/add', function(req, res, next){    
    connection.query('SELECT id, make, model, year from seller ORDER BY year desc',function(err,rows)
    {
        if(err){
            req.flash('error', err); 
            res.render('sell/add',{ title: 'Add New Sell Item', data:''});
        }else{
            res.render('sell/add',{ title: 'Add New Sell Item', data:rows });
        }
    });
})

router.get('/search', function(req, res, next){
    res.render('sell/search', {
        title: 'Search Sell History', 
        data: {}
    })
})

router.post('/add', function(req, res, next){    
    req.assert('name', 'Name is required').notEmpty()           //Validate name
    req.assert('address', 'Address is required').notEmpty();    //Validate address
    req.assert('city', 'City is required').notEmpty();          //Validate city
    req.assert('phoneNumber', 'Phone number is required').notEmpty();   //Validate phone number
    req.assert('email', 'A valid email is required').isEmail()  //Validate email
    req.assert('make', 'Make is required').notEmpty();
    req.assert('model', 'Model is required').notEmpty();
    req.assert('year', 'Year is required').notEmpty();

    var errors = req.validationErrors()
    console.log('Error: ' + !errors)

    if( !errors ) {   //No errors were found.  Passed Validation!
        var seller = {
            name: req.sanitize('name').escape().trim(),
            address: req.sanitize('address').escape().trim(),
            city: req.sanitize('city').escape().trim(),
            phoneNumber: req.sanitize('phoneNumber').escape().trim(),
            email: req.sanitize('email').escape().trim(),
            make: req.sanitize('make').escape().trim(),
            model: req.sanitize('model').escape().trim(),
            year: req.sanitize('year').escape().trim()
        }

        connection.query('INSERT INTO seller SET ?', seller, function(err, result) {
        })
        
        connection.query('SELECT id, make, model, year from seller ORDER BY year desc',function(err,rows)
        {
            if(err){
                req.flash('error', err); 
                res.render('sell/add',{ title: 'Add New Sell Item', data:''});
            }else{
                res.render('sell/add',{ title: 'Add New Sell Item', data:rows });
            }
        });
    }
    else {
        var error_msg = ''
        errors.forEach(function(error) {
            error_msg += error.msg + '<br>'
        })
        console.log(error_msg)
        req.flash('error', error_msg)
        res.render('sell/add',{ title: 'Add New Sell Item', data:'' });
    }
})

router.get('/view/(:id)', function(req, res, next){
    seller = {
        name: 'testname',
        address: 'testaddress',
        city: 'testcity',
        phoneNumber: 'testphonenumber',
        email: 'testemail',
        make: 'testmake',
        model: 'testmodel',
        year: 'testyear'
    };

    connection.query('SELECT * FROM seller WHERE id = \'' + req.params.id + '\'', function(err, rows, fields) {
        if(err) throw err
        if (rows.length <= 0) {
            req.flash('error', 'Seller not found with id = ' + req.params.id)
            res.redirect('/sell')
        }
        else {
            res.render('sell/view', {
                title: 'View Sell', 
                data: {
                    name: rows[0].name,
                    address: rows[0].address,
                    city: rows[0].city,
                    phoneNumber: rows[0].phoneNumber,
                    email: rows[0].email,
                    make: rows[0].make,
                    model: rows[0].model,
                    year: rows[0].year
                }
            });
        }            
    })
})

router.post('/search', function(req, res, next){
    param = req.sanitize('model').escape().trim()
    connection.query('SELECT * FROM seller WHERE model = \'' + param + '\'', function(err, rows, fields) {
        if(err) throw err
        console.log('dskhdsssss')
        if (rows.length <= 0) {
            req.flash('error', 'Seller not found with model = ' + param)
            res.render('sell/search', {
                title: 'View Sell', 
                data: { }
            })
        }
        else{
            console.log('dksjdkjdhksjdksjd')
            res.render('sell/search', {
                title: 'View Sell', 
                data: rows
            })
        }
    //     // if record not found
    //     if (rows.length <= 0) {
    //         req.flash('error', 'Seller not found with car id = ' + req.params.vId)
    //         res.redirect('/sell')
    //     }
    //     else { // if record found
    //         // render to views/user/edit.ejs template file
    //         res.render('sell/search', {
    //             title: 'View Sell', 
    //             //data: rows[0],
    //             name: rows[0].name,
    //             address: rows[0].address,
    //             city: rows[0].city,
    //             phoneNumber: rows[0].phoneNumber,
    //             email: rows[0].email,
    //             make: rows[0].make,
    //             model: rows[0].model,
    //             year: rows[0].year
    //         })
    //     }            
    })
})

module.exports = router;