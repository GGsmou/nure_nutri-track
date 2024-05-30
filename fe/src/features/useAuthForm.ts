import { useForm } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";

const AuthFormSchema = yup.object().shape({
  email: yup.string().email().required(),
  password: yup.string().min(8).required(),
});
type AuthFormType = yup.InferType<typeof AuthFormSchema>;

export const useAuthForm = () => {
  const { formState, register, handleSubmit } = useForm<AuthFormType>({
    resolver: yupResolver(AuthFormSchema),
    mode: "onBlur",
    defaultValues: {
      email: "",
      password: "",
    },
  });

  return {
    handlers: {
      signIn: handleSubmit((data) => console.log(data)),
      signUp: handleSubmit((data) => console.log(data)),
    },
    fields: {
      email: {
        ...register("email"),
        error: !!formState.errors.email || false,
        label: formState.errors.email?.message || "Email",
      },
      password: {
        ...register("password"),
        error: !!formState.errors.password || false,
        label: formState.errors.password?.message || "Password",
      },
    },
  };
};
