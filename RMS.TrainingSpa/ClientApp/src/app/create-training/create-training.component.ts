import { Component, OnInit, Input } from '@angular/core';
import { FormControl, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TrainingModel, Response } from '../model/model';
import { TrainingService } from '../services/training.service';
import { ValidationMessages } from '../constants/validation-messages';
@Component({
  selector: 'app-training',
  templateUrl: './create-training.component.html',
})
export class CreateTrainingComponent implements OnInit {
  trainingGroup: FormGroup;
  successMessage: string;
  constructor(private trainingService: TrainingService, private _fb: FormBuilder) { }

  ngOnInit() {
    this.trainingGroup = this._fb.group({
      startDate: ['', Validators.required],
      endDate: ['', Validators.required],
      trainingName: ['', Validators.required]
    }, { validator: this.dateLessThan('startDate', 'endDate') });/*}*/
    
  }


  createTraining() {
    let training = new TrainingModel();
    training.startDate = this.trainingGroup.get('startDate').value;
    training.endDate = this.trainingGroup.get('endDate').value;
    training.trainingName = this.trainingGroup.get('trainingName').value;

    this.trainingService.newTraining(training)
      .subscribe(data => {
        if (data.message != '' && data.status == '200') {
          this.successMessage = data.message;
        }
      });
     
      
  }
   
  dateLessThan(start: string, end: string) {
    return (group: FormGroup): { [key: string]: any } => {
      let startDate = group.controls[start];
      let endDate = group.controls[end];
      if ((startDate.value != '' && endDate.value != '') && startDate.value > endDate.value) {
        return {
          dates: ValidationMessages.DateValidationMessage
        };
      }
      return {};
    }
  }
}
