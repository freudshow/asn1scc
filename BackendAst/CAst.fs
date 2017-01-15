﻿module CAst
open System
open System.Numerics
open Antlr.Runtime.Tree
open Antlr.Runtime

open FsUtils
open Constraints
open uPER2

type AcnAligment = 
    | NextByte
    | NextWord
    | NextDWord

type IntEncodingClass =
    |Integer_uPER
    |PositiveInteger_ConstSize_8
    |PositiveInteger_ConstSize_big_endian_16
    |PositiveInteger_ConstSize_little_endian_16
    |PositiveInteger_ConstSize_big_endian_32
    |PositiveInteger_ConstSize_little_endian_32
    |PositiveInteger_ConstSize_big_endian_64
    |PositiveInteger_ConstSize_little_endian_64
    |PositiveInteger_ConstSize of int
    |TwosComplement_ConstSize_8
    |TwosComplement_ConstSize_big_endian_16
    |TwosComplement_ConstSize_little_endian_16
    |TwosComplement_ConstSize_big_endian_32
    |TwosComplement_ConstSize_little_endian_32
    |TwosComplement_ConstSize_big_endian_64
    |TwosComplement_ConstSize_little_endian_64
    |TwosComplement_ConstSize of int
    |ASCII_ConstSize of int
    |ASCII_VarSize_NullTerminated of byte
    |ASCII_UINT_ConstSize of int
    |ASCII_UINT_VarSize_NullTerminated of byte
    |BCD_ConstSize of int
    |BCD_VarSize_NullTerminated of byte



type Integer = {
    //bast inherrited properties
    id                  : ReferenceToType
    tasInfo             : BAst.TypeAssignmentInfo option
    uperMaxSizeInBits   : int
    uperMinSizeInBits   : int
    cons                : IntegerTypeConstraint list
    withcons            : IntegerTypeConstraint list
    uperRange           : uperRange<BigInteger>
    baseType            : Integer option
    Location            : SrcLoc   

    //cast new properties
    acnMaxSizeInBits    : int
    acnMinSizeInBits    : int
    alignment            : AcnAligment option
    acnEncodingClass    : IntEncodingClass
}
with 
    member this.Cons     = this.cons
    member this.WithCons = this.withcons
    member this.AllCons  = this.cons@this.withcons



and EnumAcnEncodingClass =
    | EncodeIndexes     of     IntEncodingClass
    | EncodeValues      of     IntEncodingClass 


and Enumerated = {
    id                  : ReferenceToType
    tasInfo             : BAst.TypeAssignmentInfo option
    uperMaxSizeInBits   : int
    uperMinSizeInBits   : int
    items               : BAst.EnumItem list
    userDefinedValues   : bool      //if true, the user has associated at least one item with a value
    cons                : EnumConstraint list
    withcons            : EnumConstraint list
    baseType            : Enumerated option
    Location            : SrcLoc   

    //cast new properties
    acnMaxSizeInBits    : int
    acnMinSizeInBits    : int
    alignment           : AcnAligment option
    enumEncodingClass   : EnumAcnEncodingClass
}
with 
    member this.Cons     = this.cons
    member this.WithCons = this.withcons
    member this.AllCons  = this.cons@this.withcons


and RealEncodingClass =
    | Real_uPER
    | Real_IEEE754_32_big_endian
    | Real_IEEE754_64_big_endian
    | Real_IEEE754_32_little_endian
    | Real_IEEE754_64_little_endian

and Real = {
    //bast inherrited properties
    id                  : ReferenceToType
    tasInfo             : BAst.TypeAssignmentInfo option
    uperMaxSizeInBits   : int
    uperMinSizeInBits   : int
    cons                : RealTypeConstraint list
    withcons            : RealTypeConstraint list
    uperRange           : uperRange<double>
    baseType            : Real option
    Location            : SrcLoc   

    //cast new properties
    acnMaxSizeInBits    : int
    acnMinSizeInBits    : int
    alignment            : AcnAligment option
    acnEncodingClass    : RealEncodingClass
}
with 
    member this.Cons     = this.cons
    member this.WithCons = this.withcons
    member this.AllCons  = this.cons@this.withcons


and BolleanAcnEncodingClass = {
    truePattern         : byte list
    falsePattern        : byte list
    patternSizeInBits   : int
    encodingValueIsTrue : bool
}

and Boolean = {
    id                  : ReferenceToType
    tasInfo             : BAst.TypeAssignmentInfo option
    uperMaxSizeInBits   : int
    uperMinSizeInBits   : int
    cons                : BoolConstraint list
    withcons            : BoolConstraint list
    baseType            : Boolean option
    Location            : SrcLoc   

    //cast new properties
    acnMaxSizeInBits    : int
    acnMinSizeInBits    : int
    alignment           : AcnAligment option
    acnEncodingClass    : BolleanAcnEncodingClass
}
with 
    member this.Cons     = this.cons
    member this.WithCons = this.withcons
    member this.AllCons  = this.cons@this.withcons



and NullAcnEncodingClass = {
    byteMask            : byte list
    patternSizeInBits   : int
}

and NullType = {
    id                  : ReferenceToType
    tasInfo             : BAst.TypeAssignmentInfo option
    uperMaxSizeInBits   : int
    uperMinSizeInBits   : int
    baseType            : NullType option
    Location            : SrcLoc   

    //cast new properties
    acnMaxSizeInBits    : int
    acnMinSizeInBits    : int
    alignment            : AcnAligment option
    acnEncodingClass    : NullAcnEncodingClass
}






and StringAcnEncodingClass =
    | Acn_Enc_String_Ascii_FixSize                          of size:int                     //int = the size of the fixed ascii string
    | Acn_Enc_String_Ascii_Null_Teminated                   of byte                         //byte = the null character
    | Acn_Enc_String_Ascii_External_Field_Determinant                                       //external field
    | Acn_Enc_String_Ascii_Internal_Field_Determinant       of lengDeterminantSize:int      //int = size in bits of legth determinant. This case is like uPER except that the ASCII value (8 bits) of the character is encoded and also no fragmentation     
    | Acn_Enc_String_CharIndex_FixSize                      of size:int                     //int = the size of the fixed string
    | Acn_Enc_String_CharIndex_External_Field_Determinant                                    //external field
    | Acn_Enc_String_CharIndex_Internal_Field_Determinant   of lengDeterminantSize:int      //int = size in bits of legth determinant : this case is almost like uPER (except of fragmentation)



and StringType = {
    //bast inherrited properties
    id                  : ReferenceToType
    tasInfo             : BAst.TypeAssignmentInfo option
    uperMaxSizeInBits   : int
    uperMinSizeInBits   : int
    cons                : IA5StringConstraint list
    withcons            : IA5StringConstraint list
    minSize             : int
    maxSize             : int
    charSet             : char array
    baseType            : StringType option
    Location            : SrcLoc   

    //cast new properties
    acnMaxSizeInBits    : int
    acnMinSizeInBits    : int
    alignment            : AcnAligment option
    acnEncodingClass    : StringAcnEncodingClass
    //acnArguments        : IntArgument list
}
with 
    member this.Cons     = this.cons
    member this.WithCons = this.withcons
    member this.AllCons  = this.cons@this.withcons


        

 

type SizeableAcnEncodingClass =
    | FixedSize         of int                                  // Fix size, size is equal to minSize which is equal to maxSize 
    | AutoSize                                                  // like uPER but without fragmentation
    | ExternalField                                             // the external field is written in the links section

type OctetString = {
    id                  : ReferenceToType
    tasInfo             : BAst.TypeAssignmentInfo option
    uperMaxSizeInBits   : int
    uperMinSizeInBits   : int
    cons                : OctetStringConstraint list
    withcons            : OctetStringConstraint list
    minSize             : int
    maxSize             : int
    baseType            : OctetString option
    Location            : SrcLoc   

    //cast new properties
    acnMaxSizeInBits    : int
    acnMinSizeInBits    : int
    alignment            : AcnAligment option
    acnEncodingClass    : SizeableAcnEncodingClass
    //acnArguments        : IntArgument list
}
with 
    member this.Cons     = this.cons
    member this.WithCons = this.withcons
    member this.AllCons = this.cons@this.withcons



type BitString = {
    id                  : ReferenceToType
    tasInfo             : BAst.TypeAssignmentInfo option
    uperMaxSizeInBits   : int
    uperMinSizeInBits   : int
    cons                : BitStringConstraint list
    withcons            : BitStringConstraint list
    minSize             : int
    maxSize             : int
    baseType            : BitString option
    Location            : SrcLoc   

    //cast new properties
    acnMaxSizeInBits    : int
    acnMinSizeInBits    : int
    alignment            : AcnAligment option
    acnEncodingClass    : SizeableAcnEncodingClass
    //acnArguments        : IntArgument list
}
with 
    member this.Cons     = this.cons
    member this.WithCons = this.withcons
    member this.AllCons  = this.cons@this.withcons


type SequenceOf = {
    id                  : ReferenceToType
    tasInfo             : BAst.TypeAssignmentInfo option
    uperMaxSizeInBits   : int
    uperMinSizeInBits   : int
    childType           : Asn1Type
    cons                : SequenceOfConstraint list
    withcons            : SequenceOfConstraint list
    minSize             : int
    maxSize             : int
    baseType            : SequenceOf option
    Location            : SrcLoc   

    //cast new properties
    acnMaxSizeInBits    : int
    acnMinSizeInBits    : int
    alignment            : AcnAligment option
    acnEncodingClass    : SizeableAcnEncodingClass
    //acnArguments        : GenericArgument list
}
with 
    member this.Cons     = this.cons
    member this.WithCons = this.withcons
    member this.AllCons = this.cons@this.withcons



and OptionalalityEncodingClass = 
    | OptionLikeUper
    | OptionExtField    

and Optional = {
    defaultValue        : Asn1GenericValue option
    ancEncodingClass    : OptionalalityEncodingClass
}

and Asn1Optionality = 
    | AlwaysAbsent
    | AlwaysPresent
    | Optional          of Optional


and SeqChildInfo = {
    name                :string
    chType              :Asn1Type
    optionality         :Asn1Optionality option
    acnInsertetField    :bool
    comments            :string list
}


and Sequence = {
    id                  : ReferenceToType
    tasInfo             : BAst.TypeAssignmentInfo option
    uperMaxSizeInBits   : int
    uperMinSizeInBits   : int
    children            : SeqChildInfo list
    cons                : SequenceConstraint list
    withcons            : SequenceConstraint list
    baseType            : Sequence option
    Location            : SrcLoc   

    //cast new properties
    acnMaxSizeInBits    : int
    acnMinSizeInBits    : int
    alignment           : AcnAligment option
    //acnArguments        : GenericArgument list
}
with 
    member this.Cons     = this.cons
    member this.WithCons = this.withcons
    member this.AllCons = this.cons@this.withcons




and ChoiceAcnEncClass =
    | EmbededChoiceIndexLikeUper
    | EnumDeterminant               
    | PresentWhenOnChildren

and ChChildInfo = {
    name                :string
    chType              :Asn1Type
    comments            :string list
    presenseIsHandleByExtField :bool
}

and Choice = {
    id                  : ReferenceToType
    tasInfo             : BAst.TypeAssignmentInfo option
    uperMaxSizeInBits   : int
    uperMinSizeInBits   : int
    children            : ChChildInfo list
    cons                : ChoiceConstraint list
    withcons            : ChoiceConstraint list
    baseType            : Choice option
    Location            : SrcLoc   

    //cast new properties
    acnMaxSizeInBits    : int
    acnMinSizeInBits    : int
    acnEncodingClass    : ChoiceAcnEncClass
    alignment            : AcnAligment option
    //acnArguments        : GenericArgument list
}
with 
    member this.Cons     = this.cons
    member this.WithCons = this.withcons
    member this.AllCons = this.cons@this.withcons



and Asn1Type =
    | Integer           of Integer
    | Real              of Real
    | IA5String         of StringType
    | OctetString       of OctetString
    | NullType          of NullType
    | BitString         of BitString
    | Boolean           of Boolean
    | Enumerated        of Enumerated
    | SequenceOf        of SequenceOf
    | Sequence          of Sequence
    | Choice            of Choice
with
    member this.id =
        match this with
        | Integer      t -> t.id
        | Real         t -> t.id
        | IA5String    t -> t.id
        | OctetString  t -> t.id
        | NullType     t -> t.id
        | BitString    t -> t.id
        | Boolean      t -> t.id
        | Enumerated   t -> t.id
        | SequenceOf   t -> t.id
        | Sequence     t -> t.id
        | Choice       t -> t.id
    member this.baseType =
        match this with
        | Integer      t -> t.baseType |> Option.map Integer     
        | Real         t -> t.baseType |> Option.map Real        
        | IA5String    t -> t.baseType |> Option.map IA5String   
        | OctetString  t -> t.baseType |> Option.map OctetString 
        | NullType     t -> t.baseType |> Option.map NullType    
        | BitString    t -> t.baseType |> Option.map BitString   
        | Boolean      t -> t.baseType |> Option.map Boolean     
        | Enumerated   t -> t.baseType |> Option.map Enumerated  
        | SequenceOf   t -> t.baseType |> Option.map SequenceOf  
        | Sequence     t -> t.baseType |> Option.map Sequence    
        | Choice       t -> t.baseType |> Option.map Choice      
    member this.uperMaxSizeInBits =
        match this with
        | Integer      t -> t.uperMaxSizeInBits
        | Real         t -> t.uperMaxSizeInBits
        | IA5String    t -> t.uperMaxSizeInBits
        | OctetString  t -> t.uperMaxSizeInBits
        | NullType     t -> t.uperMaxSizeInBits
        | BitString    t -> t.uperMaxSizeInBits
        | Boolean      t -> t.uperMaxSizeInBits
        | Enumerated   t -> t.uperMaxSizeInBits
        | SequenceOf   t -> t.uperMaxSizeInBits
        | Sequence     t -> t.uperMaxSizeInBits
        | Choice       t -> t.uperMaxSizeInBits
    member this.uperMinSizeInBits =
        match this with
        | Integer      t -> t.uperMinSizeInBits
        | Real         t -> t.uperMinSizeInBits
        | IA5String    t -> t.uperMinSizeInBits
        | OctetString  t -> t.uperMinSizeInBits
        | NullType     t -> t.uperMinSizeInBits
        | BitString    t -> t.uperMinSizeInBits
        | Boolean      t -> t.uperMinSizeInBits
        | Enumerated   t -> t.uperMinSizeInBits
        | SequenceOf   t -> t.uperMinSizeInBits
        | Sequence     t -> t.uperMinSizeInBits
        | Choice       t -> t.uperMinSizeInBits
    member this.acnMinSizeInBits =
        match this with
        | Integer      t -> t.acnMinSizeInBits
        | Real         t -> t.acnMinSizeInBits
        | IA5String    t -> t.acnMinSizeInBits
        | OctetString  t -> t.acnMinSizeInBits
        | NullType     t -> t.acnMinSizeInBits
        | BitString    t -> t.acnMinSizeInBits
        | Boolean      t -> t.acnMinSizeInBits
        | Enumerated   t -> t.acnMinSizeInBits
        | SequenceOf   t -> t.acnMinSizeInBits
        | Sequence     t -> t.acnMinSizeInBits
        | Choice       t -> t.acnMinSizeInBits

    member this.acnMaxSizeInBits =
        match this with
        | Integer      t -> t.acnMaxSizeInBits
        | Real         t -> t.acnMaxSizeInBits
        | IA5String    t -> t.acnMaxSizeInBits
        | OctetString  t -> t.acnMaxSizeInBits
        | NullType     t -> t.acnMaxSizeInBits
        | BitString    t -> t.acnMaxSizeInBits
        | Boolean      t -> t.acnMaxSizeInBits
        | Enumerated   t -> t.acnMaxSizeInBits
        | SequenceOf   t -> t.acnMaxSizeInBits
        | Sequence     t -> t.acnMaxSizeInBits
        | Choice       t -> t.acnMaxSizeInBits

    member this.asn1Name = 
        match this.id with
        | ReferenceToType((GenericFold2.MD _)::(GenericFold2.TA tasName)::[])   -> Some tasName
        | _                                                                     -> None


let seqUPEROptionalChildren children =
    children |> List.filter(fun c -> match c.optionality with Some (_) -> true | None -> false)
let seqAcnOptionalChildren children =
    children |> List.filter(fun c -> match c.optionality with Some (Optional _) -> true | _ -> false)
let seqAcnOptionalChildrenHandledLikeuPER children=
    children |> 
    List.filter(fun c -> 
        match c.optionality with 
        | Some (Optional o) -> 
            match o.ancEncodingClass with
            | OptionLikeUper    -> true
            | OptionExtField    -> false
        | _ -> false)

type AcnLinkKind = 
    | SizeDeterminant                               // points to an integer type that acts as a size determinant to a SEQUENCE OF, BIT STRINT, OCTET STRING etc
    | RefTypeArgument of string                     // string is the param name
    | PresenceBool                                  // points to a SEQEUNCE or Choice child
    | PresenceInt of BigInteger                     // points to a SEQEUNCE or Choice child
    | PresenceStr of string
    | ChoiceDeteterminant                           // points to Enumerated type acting as CHOICE determinant.

type AcnDeterminantType =
    | AcnType
    | AcnParameter

type AcnLink = {
    decType     : ReferenceToType
    determinant : AcnDeterminantType*ReferenceToType
    linkType    : AcnLinkKind
}


type AstRoot = AstRootTemplate<Asn1Type, BAst.AcnParameter>


let mapBastToCast (r:BAst.AstRoot) (c:AcnTypes.AcnAst): AstRoot=
    let acnMap = c.Types |> List.map(fun s -> s.TypeID |> Seq.StrJoin ".", s) |> Map.ofList
    let mapType (t:BAst.Asn1Type) : Asn1Type =
        let acnProps = 
            match acnMap.TryFind (t.id.ToString()) with
            | None  -> []
            | Some acnT -> acnT.Properties
        raise(Exception "")
    let newTypes = r.TypeAssignments |> List.map mapType
    {
        AstRoot.Files = r.Files
        Encodings = r.Encodings
        GenerateEqualFunctions = r.GenerateEqualFunctions
        TypePrefix = r.TypePrefix
        AstXmlAbsFileName = r.AstXmlAbsFileName
        IcdUperHtmlFileName = r.IcdUperHtmlFileName
        IcdAcnHtmlFileName = r.IcdUperHtmlFileName
        CheckWithOss = r.CheckWithOss
        mappingFunctionsModule = r.mappingFunctionsModule
        valsMap = r.valsMap
        typesMap = newTypes |> List.map(fun x -> x.id, x) |> Map.ofList
        TypeAssignments = newTypes
        ValueAssignments = r.ValueAssignments
        integerSizeInBytes = r.integerSizeInBytes
        acnParameters = r.acnParameters
        acnConstants = r.acnConstants
    }    