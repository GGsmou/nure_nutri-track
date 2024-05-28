import { PlayCircleOutline } from "@mui/icons-material";
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
      </div>
    </ThemeProvider>
  );
};
