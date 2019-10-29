import { Component, ViewChild } from '@angular/core';
import { QuestionsService } from './questions.service';
import { UserService } from './user.service';
import { Question } from './QuestionModel';
import { ResponseDetail } from './ResponseDetail';
import { Response } from './Response';
import { HttpHeaders } from '@angular/common/http';
import { ModalDialog } from './modal-dialog';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UserModel } from './UserModel';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json',
  })
};

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: [QuestionsService, UserService]
})

export class HomeComponent {
  //questions: Question[];  -- to be enabled when using mock questions
  public questions;
  public user;
  error: any;
  public responses: ResponseDetail[];
  public imageSrc = '../assets/headerLogo2.png';
 
  constructor(private questionsService: QuestionsService, private userService: UserService, private modalService: NgbModal) {
  }

  ngOnInit() {
    this.getQuestionsWeb();
    this.responses = [];
    this.name = '';
    this.phone = '';
    this.email = '';
    this.optIn = 0;
  }

  getQuestionsMock(): void {
    this.questionsService.getQuestionsByEntityMock(1)
      .subscribe(questions => this.questions = questions);
  }

  getQuestionsWeb(): void {
    this.questionsService.getQuestionsByEntity(1).subscribe(
      data => { this.questions = data },
      err => console.error(err),
      () => console.log('done loading questions')
    );
  }

  addResponse(surveyId, questionId, choiceId): void {
    for (var i = 0; i < this.responses.length; i++) {
        if (this.responses[i].questionId == questionId) {
          this.responses.splice(i, 1);
        }
    }
    this.responses.push(new ResponseDetail(surveyId, questionId, choiceId));
  }
  
  active: number;
  onClick(questionIndex: number, choiceIndex: number, choice: string) {
    this.addResponse(1, questionIndex, choice);        // entityId is hard coded, need to change later
    this.questions[questionIndex].activeChoice = choiceIndex;
  }

  name = '';
  getName(value: string) {
    this.name = value;
  }

  phone = '';
  //getPhone(value: string) {
  //  this.phone = value;
  //}

  email = '';
  getEmail(value: string) {
    this.email = value;
  }

  optIn = 0;

  submitBtnState() {
    var btnState = false;
    if (this.optIn == 1 && this.responses.length > 0 && this.phone != '')
      btnState = true;

    return btnState;
  }

  getUserByPhone(phone: string): any {
    return this.userService.getUserByPhone(phone).toPromise().then(data => { return data; })
  }

  async onSubmit() {

    let user = <UserModel>await this.getUserByPhone(this.phone);

    // if user is null that means the phone number has not been found, so go ahead and save response. if user is not null, display modal
    if (user == null) {

      var response = new Response(1, this.name, this.phone, this.email, this.optIn, this.responses);
      this.questionsService.saveResponse(response).subscribe(
        data => response = data)

      // display confirmation modal
      const modalRef = this.modalService.open(ModalDialog, { centered: true, size: 'sm' });
      modalRef.componentInstance.content = 'Thank you!';
      modalRef.componentInstance.type = 'info';
      this.ngOnInit();
    }
    else {
      const modalRef = this.modalService.open(ModalDialog, { centered: true, size: 'sm' });
      modalRef.componentInstance.content = 'Sorry, this offer is available only one time per phone number';
      modalRef.componentInstance.type = 'error';
      this.ngOnInit();
    }
  }
}
