import {
  CheckCircle,
  DataUsageOutlined,
  MonitorHeartOutlined,
} from "@mui/icons-material";
import {
  Box,
  Button,
  Container,
  ThemeProvider,
  Typography,
  createTheme,
} from "@mui/material";
import { Link } from "react-router-dom";

const theme = createTheme({
  palette: {
    primary: { main: "#54BD95" },
  },
});

export const Landing = () => {
  return (
    <ThemeProvider theme={theme}>
      <div>
        <Box
          minHeight="100vh"
          sx={{
            background:
              "radial-gradient(circle, rgba(255,255,255,1) 0%, rgba(82,189,170,0.3) 100%)",
          }}
        >
          <Container>
            <header>
              <Box
                sx={{
                  paddingTop: "20px",
                  display: "flex",
                  alignItems: "center",
                  justifyContent: "space-between",
                  width: "100%",
                }}
              >
                <Typography
                  variant="h1"
                  fontSize={50}
                  fontWeight="bold"
                  color="#54BD95"
                >
                  NutriTrack
                </Typography>
                <Box
                  sx={{
                    gap: 4,
                    display: "flex",
                  }}
                >
                  <Link to="/">
                    <Button
                      sx={{
                        color: "black",
                        textTransform: "none",
                      }}
                      size="large"
                    >
                      Home
                    </Button>
                  </Link>
                  <Button
                    sx={{
                      color: "black",
                      textTransform: "none",
                    }}
                    size="large"
                  >
                    Download
                  </Button>
                  <Link to="/auth">
                    <Button
                      variant="contained"
                      color="primary"
                      sx={{
                        color: "white",
                        textTransform: "none",
                      }}
                      size="large"
                    >
                      Sign Up
                    </Button>
                  </Link>
                </Box>
              </Box>
            </header>
            <Box
              sx={{
                marginTop: "130px",
                display: "flex",
                justifyContent: "space-between",
                gap: "35px",
              }}
            >
              <Box
                maxWidth="555px"
                sx={{
                  display: "flex",
                  flexDirection: "column",
                  justifyContent: "space-between",
                }}
              >
                <Typography
                  variant="h1"
                  fontWeight="bold"
                  fontSize="80px"
                  color="black"
                >
                  Empowering your health, one calorie at a time
                </Typography>
                <Box sx={{ display: "flex", gap: "70px" }}>
                  <Link to="/auth">
                    <Button
                      size="large"
                      variant="contained"
                      sx={{
                        color: "white",
                        textTransform: "none",
                      }}
                    >
                      Try now
                    </Button>
                  </Link>
                </Box>
              </Box>
              <img src="/nure_nutri-track/landing_1.png" alt="calories" />
            </Box>
            <Box mt="90px">
              <Typography
                variant="h2"
                textAlign="center"
                color="#191A15"
                fontWeight="semi-bold"
              >
                More than 10,000 happy users
              </Typography>
            </Box>
          </Container>
        </Box>
        <Box height="360px" py="50px" boxSizing="border-box">
          <Container>
            <Box display="flex" gap="20px">
              <Box
                maxWidth="50%"
                display="flex"
                flexDirection="column"
                justifyContent="space-between"
              >
                <Typography
                  variant="h3"
                  fontSize="50px"
                  color="#191A15"
                  fontWeight="semi-bold"
                  id="about"
                >
                  Our key features
                </Typography>
                <Typography variant="body2" color="#A6A6A6">
                  NutriTrack: Revolutionizing health management with a seamless
                  SaaS experience, from tracking calories to optimizing
                  nutrition.
                </Typography>
              </Box>
              <Box
                maxWidth="50%"
                display="flex"
                flexDirection="column"
                gap="50px"
              >
                <Box display="flex" gap="24px">
                  <Box
                    style={{
                      width: "60px",
                      height: "60px",
                      display: "flex",
                      justifyContent: "center",
                      alignItems: "center",
                      backgroundColor: "white",
                      flexShrink: 0,
                      borderRadius: "5px",
                      boxShadow: "0px 4px 4px rgba(0, 0, 0, 0.25)",
                    }}
                  >
                    <MonitorHeartOutlined
                      sx={{
                        width: "40px",
                        height: "40px",
                      }}
                      color="primary"
                    />
                  </Box>
                  <Box>
                    <Typography
                      variant="h5"
                      color="black"
                      fontWeight="bold"
                      fontSize="26px"
                    >
                      Calories
                    </Typography>
                    <Typography variant="body2" color="#A6A6A6" fontSize="18px">
                      Your personalized calorie companion, simplifying tracking,
                      planning, and achieving your health goals effortlessly
                    </Typography>
                  </Box>
                </Box>
                <Box display="flex" gap="24px">
                  <Box
                    style={{
                      width: "60px",
                      height: "60px",
                      display: "flex",
                      justifyContent: "center",
                      alignItems: "center",
                      backgroundColor: "white",
                      flexShrink: 0,
                      borderRadius: "5px",
                      boxShadow: "0px 4px 4px rgba(0, 0, 0, 0.25)",
                    }}
                  >
                    <DataUsageOutlined
                      sx={{
                        width: "40px",
                        height: "40px",
                      }}
                      color="primary"
                    />
                  </Box>
                  <Box>
                    <Typography
                      variant="h5"
                      color="black"
                      fontWeight="bold"
                      fontSize="26px"
                    >
                      FitFlex
                    </Typography>
                    <Typography variant="body2" color="#A6A6A6" fontSize="18px">
                      Your guide in world of exercise and fitness
                    </Typography>
                  </Box>
                </Box>
              </Box>
            </Box>
          </Container>
        </Box>
        <Box bgcolor="#FFF6F6" pt="40px">
          <Container>
            <Box display="flex" justifyContent="space-between">
              <Box>
                <Typography
                  variant="h2"
                  fontSize="50px"
                  fontWeight="bold"
                  color="#191A15"
                >
                  What Benefit Will You Get
                </Typography>
                <Box display="flex" flexDirection="column" gap="30px" mt="40px">
                  <CheckMark text="Calorie Tracking" />
                  <CheckMark text="Meal Planning" />
                  <CheckMark text="Water Intake" />
                  <CheckMark text="Exercise integration" />
                  <CheckMark text="Deep statistics" />
                </Box>
              </Box>
              <img src="/nure_nutri-track/landing_2.png" alt="men" />
            </Box>
            <Box pt="64px" pb="70px">
              <Typography
                textAlign="center"
                fontSize="50px"
                fontWeight="bold"
                color="#191A15"
              >
                Choose Plan <br /> That&apos;s Right For You
              </Typography>
              <Box pt="50px" display="flex" gap="30px" alignItems="center">
                <Box
                  width="33%"
                  display="flex"
                  flexDirection="column"
                  alignItems="center"
                  bgcolor="#FFFFFF"
                  borderRadius="20px"
                  p="20px"
                  boxShadow="0px 4px 4px rgba(0, 0, 0, 0.25)"
                >
                  <Typography
                    fontSize="30px"
                    fontWeight="bold"
                    color="#191A15"
                    mt="40px"
                  >
                    Free
                  </Typography>
                  <Typography
                    textAlign="center"
                    fontSize="16px"
                    color="#A6A6A6"
                    mt="10px"
                  >
                    Have a go and test your
                    <br />
                    superpowers
                  </Typography>
                  <Typography fontSize="50px" color="#191A15" mt="13px">
                    0$
                  </Typography>
                  <Box
                    width="100%"
                    borderRadius="10px"
                    bgcolor="#F9FAFB"
                    p="40px"
                    display="flex"
                    flexDirection="column"
                    gap="20px"
                    boxSizing="border-box"
                  >
                    <CheckMark text="1 Account" />
                    <CheckMark text="Water Intake Tracking" />
                    <CheckMark text="Public Share & Comments" />
                    <CheckMark text="Support Through Email " />
                    <CheckMark text="Free Recipes" />
                    <Link
                      to="/auth"
                      style={{
                        width: "100%",
                      }}
                    >
                      <Button
                        sx={{
                          bgcolor: "white",
                          textTransform: "none",
                          boxShadow: "0px 4px 4px rgba(0, 0, 0, 0.25)",
                          borderRadius: "20px",
                          height: "64px",
                          width: "100%",
                        }}
                        size="large"
                      >
                        Signup for free
                      </Button>
                    </Link>
                  </Box>
                </Box>
                <Box
                  width="33%"
                  display="flex"
                  flexDirection="column"
                  alignItems="center"
                  bgcolor="#54BD95"
                  borderRadius="20px"
                  p="20px"
                  boxShadow="0px 4px 4px rgba(0, 0, 0, 0.25)"
                >
                  <Typography
                    fontSize="30px"
                    fontWeight="bold"
                    color="#FFFFFF"
                    mt="40px"
                  >
                    Pro
                  </Typography>
                  <Typography
                    textAlign="center"
                    fontSize="16px"
                    color="#FFFFFF"
                    mt="10px"
                  >
                    Experiment the power
                    <br />
                    of infinite possibilities
                  </Typography>
                  <Typography fontSize="50px" color="#FFFFFF" mt="13px">
                    8$
                  </Typography>
                  <Typography
                    bgcolor="#85DAB9"
                    color="#FFFFFF"
                    p="10px"
                    fontWeight="bold"
                    borderRadius="10px"
                  >
                    Save $50 a year
                  </Typography>
                  <Box
                    width="100%"
                    borderRadius="10px"
                    bgcolor="#F9FAFB"
                    p="40px"
                    display="flex"
                    flexDirection="column"
                    gap="20px"
                    mt="10px"
                    boxSizing="border-box"
                  >
                    <CheckMark text="1 Account" />
                    <CheckMark text="All Feature of Free Plan" />
                    <CheckMark text="All App Features" />
                    <CheckMark text="Support Through a Live Chat" />
                    <CheckMark text="All Recipes" />
                    <Link
                      to="/payment?tier=t-2&redirect=true"
                      style={{
                        width: "100%",
                      }}
                    >
                      <Button
                        sx={{
                          bgcolor: "#54BD95",
                          color: "white",
                          textTransform: "none",
                          ":hover": {
                            bgcolor: "#85DAB9",
                          },
                          boxShadow: "0px 4px 4px rgba(0, 0, 0, 0.25)",
                          borderRadius: "20px",
                          height: "64px",
                          width: "100%",
                        }}
                        size="large"
                      >
                        Go to pro
                      </Button>
                    </Link>
                  </Box>
                </Box>
                <Box
                  width="33%"
                  display="flex"
                  flexDirection="column"
                  alignItems="center"
                  bgcolor="#FFFFFF"
                  borderRadius="20px"
                  p="10px"
                  boxShadow="0px 4px 4px rgba(0, 0, 0, 0.25)"
                >
                  <Typography
                    fontSize="30px"
                    fontWeight="bold"
                    color="#191A15"
                    mt="40px"
                  >
                    Business
                  </Typography>
                  <Typography
                    textAlign="center"
                    fontSize="16px"
                    color="#A6A6A6"
                    mt="10px"
                  >
                    Unveil new superpowers and
                    <br />
                    join NutriTrack
                  </Typography>
                  <Typography fontSize="50px" color="#191A15" mt="13px">
                    16$
                  </Typography>
                  <Box
                    width="100%"
                    borderRadius="10px"
                    bgcolor="#F9FAFB"
                    p="40px"
                    display="flex"
                    flexDirection="column"
                    gap="20px"
                    boxSizing="border-box"
                  >
                    <CheckMark text="All the features of pro plan" />
                    <CheckMark text="Unlimited accounts" />
                    <CheckMark text="Improved security" />
                    <CheckMark text="Company statistics" />
                    <CheckMark text="Fastest Support" />
                    <Link
                      to="/payment?tier=t-3&redirect=true"
                      style={{
                        width: "100%",
                      }}
                    >
                      <Button
                        sx={{
                          bgcolor: "white",
                          textTransform: "none",
                          boxShadow: "0px 4px 4px rgba(0, 0, 0, 0.25)",
                          borderRadius: "20px",
                          height: "64px",
                          width: "100%",
                        }}
                        size="large"
                      >
                        Goto Business
                      </Button>
                    </Link>
                  </Box>
                </Box>
              </Box>
            </Box>
          </Container>
        </Box>
        <Box bgcolor="#161C28" pt="10px" pb="10px">
          <Container>
            <Typography
              fontWeight="bold"
              fontSize="50px"
              color="white"
              textAlign="center"
            >
              People are Saying About NutriTrack
            </Typography>
            <Box display="flex" mt="50px" justifyContent="space-between">
              <Box width="40%">
                <Typography color="#A6A6A6" fontSize="16px">
                  NutriTrack has been a game-changer for my daily health
                  routine! The user-friendly interface made it a breeze to set
                  goals and track my progress. I especially love the hydration
                  reminders—they&apos;ve ensured I drink enough water throughout
                  the day. Highly recommended for anyone serious about improving
                  their wellness!
                </Typography>
                <Box display="flex" gap="20px" alignItems="center" mt="20px">
                  <img src="/nure_nutri-track/landing_3.png" alt="Andrew" />
                  <Typography color="#A6A6A6">Andrew Fishermann</Typography>
                </Box>
              </Box>
              <Box width="40%">
                <Typography color="#A6A6A6" fontSize="16px">
                  I&apos;m genuinely impressed with NutriTrack! The seamless
                  integration with my fitness wearables allows me to keep all my
                  health data in one place. The recipe collection feature is a
                  delightful bonus, making healthy eating easier and more
                  enjoyable. This app has become my go-to for a healthier
                  lifestyle!
                </Typography>
                <Box display="flex" gap="20px" alignItems="center" mt="20px">
                  <img src="/nure_nutri-track/landing_4.png" alt="Andrew" />
                  <Typography color="#A6A6A6">Emiliano Curtosi</Typography>
                </Box>
              </Box>
            </Box>
            <Typography
              fontSize="16px"
              color="white"
              textAlign="center"
              mt="120px"
            >
              © 2024 NutriTrack Inc. Copyright and rights reserved
            </Typography>
          </Container>
        </Box>
      </div>
    </ThemeProvider>
  );
};

const CheckMark = ({ text }: { text: string }) => {
  return (
    <Box display="flex" alignItems="center" gap="10px">
      <CheckCircle
        color="primary"
        sx={{
          width: "32px",
          height: "32px",
        }}
      />
      <Typography fontSize="18px" fontWeight="medium" color="#191A15">
        {text}
      </Typography>
    </Box>
  );
};
