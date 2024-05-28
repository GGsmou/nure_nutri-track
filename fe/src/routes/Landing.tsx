import {
  CheckCircle,
  DataUsageOutlined,
  MonitorHeartOutlined,
  PlayCircleOutline,
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
                  <Button
                    sx={{
                      color: "black",
                      textTransform: "none",
                    }}
                    size="large"
                  >
                    Home
                  </Button>
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
                  <Button
                    startIcon={<PlayCircleOutline />}
                    size="large"
                    sx={{
                      color: "black",
                      textTransform: "none",
                    }}
                  >
                    About us
                  </Button>
                </Box>
              </Box>
              <img src="/landing_1.png" alt="calories" />
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
        <Box bgcolor="#FFFFFF" pt="40px">
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
              <img src="/landing_2.png" alt="men" />
            </Box>
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
