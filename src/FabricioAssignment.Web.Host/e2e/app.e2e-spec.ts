import { FabricioAssignmentTemplatePage } from './app.po';

describe('FabricioAssignment App', function() {
  let page: FabricioAssignmentTemplatePage;

  beforeEach(() => {
    page = new FabricioAssignmentTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
