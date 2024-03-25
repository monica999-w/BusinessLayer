using BusinessLayer.Entities;
using BusinessLayer.Exceptions;
using BusinessLayer.Repository;

namespace BusinessLayer
{
    public static class SpeakerExtension
    {
        public static int Register(this Speaker speaker, IRepository<Speaker> repository, Data data)
        {
            try
            {
                IsValid(speaker);
                IsGood(speaker, data);
                ApprovingSessions(speaker, data);
                SetRegistrationFee(speaker);
                return repository.Save(speaker);
            }
            catch (ArgumentNullException m)
            {
                Console.WriteLine(m.Message);
                return -1;

            }
            catch (ArgumentException m)
            {
                Console.WriteLine(m.Message);
                return -1;

            }
            catch (SpeakerDoesntMeetRequirementsException m)
            {
                Console.WriteLine(m.Message);
                return -1;

            }
            catch (NoSessionsApprovedException m)
            {
                Console.WriteLine(m.Message);
                return -1;

            }
        }

        private static void SetRegistrationFee(Speaker speaker)
        {
            if (speaker.Exp <= 1)
            {
                speaker.RegistrationFee = 500;
            }
            else if (speaker.Exp >= 2 && speaker.Exp <= 3)
            {
                speaker.RegistrationFee = 250;
            }
            else if (speaker.Exp >= 4 && speaker.Exp <= 5)
            {
                speaker.RegistrationFee = 100;
            }
            else if (speaker.Exp >= 6 && speaker.Exp <= 9)
            {
                speaker.RegistrationFee = 50;
            }
            else
            {
                speaker.RegistrationFee = 0;
            }
        }

        private static void ApprovingSessions(Speaker speaker, Data data)
        {
            //DEFECT #5013 CO 1/12/2012
            //We weren't requiring at least one session
            if (speaker.Sessions.Count() == 0)
            {
                throw new ArgumentException("Can't register speaker with no sessions to present.");
            }
            bool appr = false;

            foreach (var session in speaker.Sessions)
            {
                

                foreach (var tech in data.Ot)
                {
                    if (session.Title.Contains(tech) || session.Description.Contains(tech))
                    {
                        session.Approved = false;
                        break;
                    }
                    else
                    {
                        session.Approved = true;
                        appr = true;
                    }
                }
            }

            if (!appr)
            {
                throw new NoSessionsApprovedException("No sessions approved.");
            }
        }

        private static void IsValid(Speaker speaker)
        {
            if (string.IsNullOrWhiteSpace(speaker.FirstName))
            {
                throw new ArgumentException("First Name is required");
            }

            if (string.IsNullOrWhiteSpace(speaker.LastName))
            {
                throw new ArgumentException("Last name is required.");
            }

            if (string.IsNullOrWhiteSpace(speaker.Email))
            {
                throw new ArgumentException("Email is required.");
            }
        }
        private static void IsGood(Speaker speaker, Data data)
        {
            //DFCT #838 Jimmy
            //We're now requiring 3 certifications so I changed the hard coded number. Boy, programming is hard.
            bool good = speaker.Exp > 10 || speaker.HasBlog || speaker.Certifications.Count() > 3 || data.Emps.Contains(speaker.Employer);

            if (!good)
            {
                //need to get just the domain from the email
                string emailDomain = speaker.Email.Split('@').Last();

                if (!data.Domains.Contains(emailDomain) && (!(speaker.Browser.Name == WebBrowser.BrowserName.InternetExplorer && speaker.Browser.MajorVersion < 9)))
                {
                    good = true;
                }
            }

            if (!good)
            {
                throw new SpeakerDoesntMeetRequirementsException("Speaker doesn't meet our abitrary and capricious standards.");
            }
        }
    }
}
