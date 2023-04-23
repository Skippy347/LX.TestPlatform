import { Box, Typography } from "@mui/material";
import styles from "./IntroSection.module.scss";
import { LoginForm } from "../LoginForm";

export function IntroSection() {
  return (
    <Box className={styles.intro}>
      <Box className="container">
        <Box className={styles.intro_inner}>
          <Typography className={styles.intro_title}>Sign in to continue</Typography>
          <LoginForm />
        </Box>
      </Box>
    </Box>
  );
}
