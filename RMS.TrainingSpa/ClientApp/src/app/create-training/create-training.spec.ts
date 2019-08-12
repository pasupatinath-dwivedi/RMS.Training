import { async, ComponentFixture, TestBed,inject } from '@angular/core/testing';
import { CreateTrainingComponent } from './create-training.component';
import { ValidationMessages } from '../constants/validation-messages';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { TrainingService } from '../services/training.service'
import { HttpClient } from "@angular/common/http";
import { HttpClientTestingModule } from '@angular/common/http/testing';


describe('CreateTrainingComponent', () => {
  let component: CreateTrainingComponent;
  let fixture: ComponentFixture<CreateTrainingComponent>;
  let trainingService: TrainingService;


  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CreateTrainingComponent],
      imports: [
        FormsModule, ReactiveFormsModule, HttpClientTestingModule],
      providers: [TrainingService,HttpClient]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateTrainingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    trainingService = TestBed.get(TrainingService);
  });

  it('should create', async (inject([TrainingService],(trainingService: TrainingService) => {
    expect(component).toBeTruthy();
  })));



  it('should display a title', async(() => {
    const titleText = fixture.nativeElement.querySelector('h1').textContent;
    
    expect(titleText).toEqual('New Training');
  }));

  it('form should be invalid', async(() => {
    component.trainingGroup.controls['trainingName'].setValue('');
    component.trainingGroup.controls['startDate'].setValue('');
    component.trainingGroup.controls['endDate'].setValue('');
    
    expect(component.trainingGroup.valid).toBeFalsy();

  }));
});
