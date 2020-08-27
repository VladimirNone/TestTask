import { ForInterviewTemplatePage } from './app.po';

describe('ForInterview App', function() {
  let page: ForInterviewTemplatePage;

  beforeEach(() => {
    page = new ForInterviewTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
