/*
created by   : dwi.prash@gmail.com
created date : 2022.12.21
description  : testing application to consume rest api
note:        : still need validation here
*/


import { Component } from '@angular/core';
import { HttpService } from './http-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(private httpService: HttpService) { }

userInput: any = undefined;

result: any = undefined;

options: any[] = [
  {id: 0, desc: 'Select option', url: '', exampleValue: ''},
  {id: 1, desc: 'Sum', url: 'sum', exampleValue: 'eg: 5,2,3,5,3'},
  {id: 2, desc: 'Subtract', url: 'subtract', exampleValue: 'eg: 25,2,3,5,3'},
  {id: 3, desc: 'Multiply', url: 'multiply', exampleValue: 'eg: 2,4,3,5'},
  {id: 4, desc: 'Divide', url: 'divide', exampleValue: 'eg: 16,4'},
  {id: 5, desc: 'SplitEq', url: 'split-eq', exampleValue: 'eg: 120, 4'},
  {id: 6, desc: 'SplitNum', url: 'split', exampleValue: 'eg: 140,45,35,20'},
]

selectedOption:any = this.options[0];


onChanged(selectedObj:any) { 
  if (selectedObj.id != 0) {
    this.selectedOption = selectedObj;
    this.userInput = undefined;
  }
}

onSubmit() {  
  this.result = undefined;
  var tempe = this.userInput.split(',');
  console.log(tempe)

  this.httpService.postRequest(this.selectedOption.url, this.userInput.split(',')).subscribe(
    res => {
      console.log(res)
      this.result = res.data;
    },
    err => {
      console.error(err)
    },
    () => {
      console.log('done')
    }
  )
}

}
