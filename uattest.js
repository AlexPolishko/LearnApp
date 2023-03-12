import http from 'k6/http';

export let options = {
insecureSkipTLSVerify: true,
noConnectionReuse: false,
vus: 10,
duration: '100s'
};

export default()=>{
  //  let response = http.get('https://uatmobile.int.sportingindex.com/api/Meetings/GetInPlay?marketLimit=3',);
//console.log('length '+JSON.stringify(response).length)
http.post('https://uatmobile.int.sportingindex.com/api/Punter/Login',{Username: 'A12121',Password: 'sdadsa2323'});
	}